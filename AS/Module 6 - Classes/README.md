# Module 6 - Classes
This module introduces the topic of [Object Oriented Programming](https://en.wikipedia.org/wiki/Object-oriented_programming) (**OOP**) in the form of `class`es, as well as access modifiers such as `public` and `private`.
### Reminder:
<ul>

All information covered here is _**NOT**_ directly taken from our booklets, classes, or revision material, _**DO NOT**_ **refer to the definitions given in these overviews for definition-reciting questions.**
</ul>

## Objects Basics

Objects may be defined as shown:
```cs
// Class definition
public class Person {

    // Default constructor
    public Person() {
        ...
    }
    
    // Field-setting constructor
    public Person(string _name, int _age, float _height) {
        ...
    }

    // Public member function
    public void have_birthday() {
        ...
    }

    // We've been taught that to make get/setters you would do:
    //   private string name;
    //   public string get_name() { ... }
    //   public void set_name() { ... }

    // However the above can be achieved with just:
    //   public string name {
    //      get;
    //      private set;
    //   }
    //   public void set_name() { ... }

    // Public field
    public System.Collections.Generic.List<Person> friends;

    // Public property
    public string name {
        get;
        private set;
    }

    public int age {
        get;
        private set;
    }

    private float height {
        get;
        private set;
    }

}
```
We'll be using the above as a reference for the purposes of the notes in this section.

Objects are composed of other "primitive" datatypes, and are used as blueprints for collections of related variables (with the exception of `static` classes), think of a class as being a blueprint for a type, that is made up of a bunch of other types.

Objects (with the exception of `static` and `abstract` classes) must be **instantiated** to be used, e.g:
```cs
Person rory = new Person();
```

The act of instantiation requires the use of a **constructor**, all objects have one by default that takes no parameters.

Objects may have multiple constructors, the above class has two: `Person.Person()` (the **default constructor**), and `Person.Person(string, int, float)`. (the **field setting constructor**)

Objects without an explicitly declared constructor (like our field setting constructor above) will be automatically given a default constructor. Because our object above makes use of a field setting constructor, we also have to make the default constructor ourselves, because it isn't automatically given to us.

Objects may contain the following things:
* Fields (variables)
* Properties (get/set)
* Constructors (functions with the same name as the class)
* Methods (I call these functions, get used to it)
* Class/Enum/Struct definitions (yep, you can make a class inside of a class)

Objects are passed by reference, not by value.

All values in a class are `private` by default.

<details>
<summary>More stuff not yet covered but might be</summary>
<ul>

### Static Classes:

Classes can be made `static`, this makes the class act as a globally accessible instance of itself, and makes instantiating the class impossible, this is known as the **singleton** pattern, the name being a holdover from the C++ pattern implementing similar functionality.

Static classes may only contain static members with the exception of definitions of other `class`es, `struct`s, and `enum`s, which may be non-static.

### Generic Classes:

Classes can be made generic, e.g:
```cs
class List<T> {
    ...
    T[] underlying_list;
    ...
}

...

List<int> list_of_numbers = new List<int>();
```

This allows for classes with functionality for multiple primitives/classes, a similar functionality may be given to functions.

### Interfaces:
Classes may inherit from what is known as an `interface`, which may specify virtual functions that all derived classes must implement. This allows for the emulation of multiple inheritance at the cost of some awkward generics.

Interfaces may define a default implementation, however this is rarely applicable, and only saves on some minor boilerplate.

### Abstract Classes:

Classes can be made `abstract`, this makes the class act as an `interface` without the limitation of not allowing access modifiers, or `class`/`struct`/`enum` definitions.

Unlike interfaces, only one abstract class may be inherited by any other class. Use interfaces for multiple inheritance.

Abstract classes may only contain `virtual` members, once again with the exception of enclosed `class`/`struct`/`enum` definitions.
</ul>
</details><br/>

## Principals of OOP
Along with the introduction of OOP is the introduction of it's core principals:
* [Abstraction](#Abstraction)
* [Composition](#Composition)
* [Encapsulation](#Encapsulation)
* [Inheritance](#Inheritance)
* [Polymorphism](#Polymorphism)
## Abstraction:
The hiding away of unnecessary detail for the purposes of increasing productivity for users of the class.

This is inherent to OOP, so I can't provide an example.
<br/>

## Composition:
The combination of smaller types to make larger types.

This will be your main goal 99% of the time, so you won't think about it too hard.
<details>
<summary>Example</summary>

```cs
class Matrix {
    int component_1;
    int component_2;
    // etc..
}
```
</details>
</br>

## Encapsulation:
The containment of all function related to a specific task should be contained within it's appropriate `class` or it's derived classes (provided it uses classes).

<details>
<summary>IMPORTANT: Example of encapsulation</summary>
<ul>

Let's say we have a `class Player` and a `class Zombie`

If the Player wishes to attack the zombie, so we call a method `Player.Attack(Zombie)`, this breaches encapsulation as the method `Player.Attack()` requires a `Zombie`, which is not related to the `Player`!

The fix for this is to have a base class `Entity` with a method `Entity.Attack(Entity)`, so we can have `Player : Entity` and `Zombie : Entity`, so now if we wish to attack the zombie we can call `Entity.Attack(Entity)`, keeping both the `Player` and `Zombie` encapsulated.
</ul>
</details><br/>

## Inheritance:
Extendability of existing functionality via reuse of code in other classes via `extending` them, e.g:
```cs
class Base {
    public string BaseFunc() {
        return "This is from base!";
    }
}

class Derived : Base {
    public void DerivedFunc() {
        Console.WriteLine(BaseFunc());
    }
}
```
<details>
<summary>Extra info that isn't on the course</summary>
<ul>

Extension is typically considered bad practice under most circumstances by experienced programmers, this is due to having to balance the requirements and restrictions of the base class ontop of managing the functionality of the derived class.

In continuation of the above, most experienced programmers will opt to instead use other systems such as **entity component systems**, or to program using just functions and non-derived classes. Both of these styles tend to offer more flexibility than object oriented systems.<br/><br/>

_"If it looks like a duck, swims like a duck, and quacks like a duck, then it probably is a duck."_
</ul>
</details>
<br/>

## Polymorphism:
Interchangeability of one or more classes in terms of function, usually achieved with an `abstract Class`, an `interface`, or a base class with various `virtual` members.
<details>
<summary>Trivia that isn't on the course</summary>
<ul>

In C++, `abstract class`es and `interface`s didn't exist, but were instead implicitly created from `class`es containing only `virtual` members, this was not carried over into C# for easier reading and writing of code.

In C++, there was no need for `interfaces`, as `class`es could inherit from multiple other `class`es, including `abstract class`es, this made object oriented design simpler at the cost of code being harder to debug.
</ul>
</details>

<br/>

# Access Modifiers
There are three main access modifiers:
* `public`
* `private`
* `protected`

There are also some more niche modifiers such as:
* `internal` (think of this as "`public internal`")
* `private internal`
* `private protected`
<ul><il>These modifiers you will likely never use</il></ul>

Access modifiers control what other classes may access members of the class being defined, with `public` members accessible by everyone, `private` members accessible only in the class being defined, and `protected` members accessible only in the class being defined and it's derived classes.

In addition to the three main specifiers, the `internal` modifier may be applied in conjunction with any other modifier to make the member only available within it's assembly (assembly's _probably_ won't be covered in this course), on top of the other modifier's restrictions. E.g: `protected internal` members can only be accessed by derived classes within the base class's assembly.

Note that access modifiers are a subtype of regular modifiers, such as `static`, `virtual`, and `abstract`, which will likely be covered in greater detail in a later module.