﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using SecProbRec19.Data;
using SecProbRec19.Models;

namespace SecProbRec19.Controllers
{
    public class ReceivesController : Controller
    {
        private readonly SecProbRec19Context _context;

        public ReceivesController(SecProbRec19Context context)
        {
            _context = context;
        }

        public IActionResult ProbConclude()
        {
            return View();
        }

        // GET: Receives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Receive.ToListAsync());
        }

        // GET: Receives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receive = await _context.Receive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receive == null)
            {
                return NotFound();
            }

            return View(receive);
        }

        // GET: Receives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MailId,RecDate")] Receive receive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receive);
        }

        //SET AUTOCREATE WHEN ID_MAIL BE SET IN URI
        [HttpGet] //que doido é um get!!! by GPT
        public async Task<IActionResult> AutoCreate(int mailId)
        {
            //var ipAddress = HttpContext.Connection.RemoteIpAddress;
            DateTime thisTime = DateTime.Now;
            var brazilTime = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            var newReceive = new Receive
            {
                MailId = mailId,
                IpAddress = GetIpAdress.Client(),
                RecDate = TimeZoneInfo.ConvertTime(DateTime.Now,
                                                   TimeZoneInfo.Local,
                                                   brazilTime)
            };


            _context.Add(newReceive);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
            //return RedirectToAction(nameof(ProbConclude));
            //return View();
        }

        // GET: Receives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receive = await _context.Receive.FindAsync(id);
            if (receive == null)
            {
                return NotFound();
            }
            return View(receive);
        }

        // POST: Receives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MailId,RecDate")] Receive receive)
        {
            if (id != receive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiveExists(receive.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(receive);
        }

        // GET: Receives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receive = await _context.Receive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receive == null)
            {
                return NotFound();
            }

            return View(receive);
        }

        // POST: Receives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receive = await _context.Receive.FindAsync(id);
            _context.Receive.Remove(receive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiveExists(int id)
        {
            return _context.Receive.Any(e => e.Id == id);
        }
    }
}
