
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Generate an array of 10 people using the class Person with random data
Person[] people = new Person[10];
var random = new Random();

for (int i = 0; i < 10; i++)
{
	people[i] = new Person
	{
		Name = "Person " + i,
		Age = random.Next(18, 100),
		Address = "Address " + i,
		Email = "person" + i + "@gmail.com",
		PhoneNumber = "1234567890",
		Date = DateTime.Now,
		City = "City " + i,
		State = "State " + i,
		Country = "Country " + i
	};
}

// Get the full name of the first person
var fullName = GetFullName(people[0]);

static string GetFullName(Person person)
{
	return person.Name + " " + person.Lastname;
}

/// <summary>
/// Represents a person.
/// </summary>
public class Person
{
	/// <summary>
	/// Gets or sets the name of the person.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Gets or sets the last name of the person.
	/// </summary>
	public string Lastname { get; set; }

	/// <summary>
	/// Gets or sets the age of the person.
	/// </summary>
	public int Age { get; set; }

	/// <summary>
	/// Gets or sets the address of the person.
	/// </summary>
	public string Address { get; set; }

	/// <summary>
	/// Gets or sets the email of the person.
	/// </summary>
	public string Email { get; set; }

	/// <summary>
	/// Gets or sets the phone number of the person.
	/// </summary>
	public string PhoneNumber { get; set; }

	/// <summary>
	/// Gets or sets the date of the person.
	/// </summary>
	public DateTime Date { get; set; }

	/// <summary>
	/// Gets or sets the city of the person.
	/// </summary>
	public string City { get; set; }

	/// <summary>
	/// Gets or sets the state of the person.
	/// </summary>
	public string State { get; set; }

	/// <summary>
	/// Gets or sets the country of the person.
	/// </summary>
	public string Country { get; set; }
}
