using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementPerson.Models;

namespace ManagementPerson.Controllers
{
    public class PeopleController : Controller
    {
        private readonly MyDbContext _context;

        public PeopleController(MyDbContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index(string searchString)
        {
            var people = from p in _context.People.Include(p => p.Address)
                         select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                people = people.Where(p => p.Name.Contains(searchString));
            }

            return View(await people.ToListAsync());
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person;
                if (model.Role == "Student")
                {
                    person = new Student
                    {
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        EmailAddress = model.EmailAddress,
                        Address = new Address
                        {
                            Name = model.AddressName,
                            Number = model.AddressNumber
                        },
                        StudentNumber = model.StudentNumber,
                        AverageMark = model.AverageMark.Value
                    };
                }
                else
                {
                    person = new Professor
                    {
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        EmailAddress = model.EmailAddress,
                        Address = new Address
                        {
                            Name = model.AddressName,
                            Number = model.AddressNumber
                        },
                        Salary = model.Salary.Value
                    };
                }

                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: People/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.PersonId == id);

            if (person == null)
            {
                return NotFound();
            }

            var model = new EditPersonViewModel
            {
                PersonId = person.PersonId,
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                EmailAddress = person.EmailAddress,
                AddressName = person.Address.Name,
                AddressNumber = person.Address.Number,
                Role = person is Student ? "Student" : "Professor"
            };

            if (person is Student student)
            {
                model.StudentNumber = student.StudentNumber;
                model.AverageMark = student.AverageMark;
            }
            else if (person is Professor professor)
            {
                model.Salary = professor.Salary;
            }

            return View(model);
        }

        // POST: People/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = await _context.People
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.PersonId == model.PersonId);

                if (person == null)
                {
                    return NotFound();
                }

                person.Name = model.Name;
                person.PhoneNumber = model.PhoneNumber;
                person.EmailAddress = model.EmailAddress;
                person.Address.Name = model.AddressName;
                person.Address.Number = model.AddressNumber;

                if (model.Role == "Student")
                {
                    var student = person as Student;
                    if (student != null)
                    {
                        student.StudentNumber = model.StudentNumber;
                        student.AverageMark = model.AverageMark;
                    }
                }
                else if (model.Role == "Professor")
                {
                    var professor = person as Professor;
                    if (professor != null)
                    {
                        professor.Salary = model.Salary;
                    }
                }
                _context.People.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
               
            }
            return View(model);
        }
        

        // GET: People/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People.Include(p => p.Address).FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.People.FindAsync(id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }
    }
}
