using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tryProject.Data;
using tryProject.Models;

namespace tryProject.Controllers
{
    public class UsersController : Controller
    {
       
        private readonly tryProjectContext _context;

        public UsersController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: Users/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public async Task<IActionResult> Register([Bind("UserName,Password,Volunteer,Name,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                var q = _context.User.FirstOrDefault(u => u.UserName == user.UserName);
                if (q == null)
                {
                    _= _context.Add(entity : user);
                    await _context.SaveChangesAsync();
                    var u = _context.User.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                    Signin(u);
                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                    ViewData["Error"] = "Unable to comply; cannot register this user.";

            }
            return View(user);
        }



        public async Task<IActionResult> Logout()
        {
            //HttpContext.Session.Clear();

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }


        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        // POST: Users/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
               var q = _context.User.FirstOrDefault(u => u.UserName == user.UserName&& u.Password==user.Password);
                if (q != null)
                {
                    // HttpContext.Session.SetString("username", q.UserName);
                    Signin(q);      
                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                    ViewData["Error"] = "UserName and/or password are incorrect.";

            }
            return View(user);
        }
        private async void Signin(User account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Role, account.Type.ToString()),
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
            };
             await HttpContext.SignInAsync(
                 CookieAuthenticationDefaults.AuthenticationScheme,
             new ClaimsPrincipal(claimsIdentity),
             authProperties)
             ;}

                /*
                        // GET: Users
                        public async Task<IActionResult> Index()
                        {
                            return View(await _context.User.ToListAsync());
                        }

                        // GET: Users/Details/5
                        public async Task<IActionResult> Details(string id)
                        {
                            if (id == null)
                            {
                                return NotFound();
                            }

                            var user = await _context.User
                                .FirstOrDefaultAsync(m => m.Id == id);
                            if (user == null)
                            {
                                return NotFound();
                            }

                            return View(user);
                        }

                        // GET: Users/Create
                        public IActionResult Create()
                        {
                            return View();
                        }

                        // POST: Users/Create
                        // To protect from overposting attacks, enable the specific properties you want to bind to.
                        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                        [HttpPost]
                        [ValidateAntiForgeryToken]
                        public async Task<IActionResult> Create([Bind("Id,Password,Type,Volunteer,Name,Email")] User user)
                        {
                            if (ModelState.IsValid)
                            {
                                _context.Add(user);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                            return View(user);
                        }

                        // GET: Users/Edit/5
                        public async Task<IActionResult> Edit(string id)
                        {
                            if (id == null)
                            {
                                return NotFound();
                            }

                            var user = await _context.User.FindAsync(id);
                            if (user == null)
                            {
                                return NotFound();
                            }
                            return View(user);
                        }

                        // POST: Users/Edit/5
                        // To protect from overposting attacks, enable the specific properties you want to bind to.
                        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                        [HttpPost]
                        [ValidateAntiForgeryToken]
                        public async Task<IActionResult> Edit(string id, [Bind("Id,Password,Type,Volunteer,Name,Email")] User user)
                        {
                            if (id != user.Id)
                            {
                                return NotFound();
                            }

                            if (ModelState.IsValid)
                            {
                                try
                                {
                                    _context.Update(user);
                                    await _context.SaveChangesAsync();
                                }
                                catch (DbUpdateConcurrencyException)
                                {
                                    if (!UserExists(user.Id))
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
                            return View(user);
                        }

                        // GET: Users/Delete/5
                        public async Task<IActionResult> Delete(string id)
                        {
                            if (id == null)
                            {
                                return NotFound();
                            }

                            var user = await _context.User
                                .FirstOrDefaultAsync(m => m.Id == id);
                            if (user == null)
                            {
                                return NotFound();
                            }

                            return View(user);
                        }

                        // POST: Users/Delete/5
                        [HttpPost, ActionName("Delete")]
                        [ValidateAntiForgeryToken]
                        public async Task<IActionResult> DeleteConfirmed(string id)
                        {
                            var user = await _context.User.FindAsync(id);
                            _context.User.Remove(user);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }

                        private bool UserExists(string id)
                        {
                            return _context.User.Any(e => e.Id == id);
                        }
                */
            }
}
