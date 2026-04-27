# 🐍 Snake Console Game (C# / .NET 8)

A simple Snake game built in pure C# using the console.
No external libraries required — perfect for low-resource environments (like `nomodeset`).

---

## 📦 Requirements

Before running the project, make sure you have:

* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

You can verify your installation with:

```bash
dotnet --version
```

---

## 🚀 How to Clone and Run

1. Clone the repository:

```bash
git clone https://github.com/your-username/snake-console-game.git
```

2. Navigate into the project folder:

```bash
cd snake-console-game
```

3. Run the game:

```bash
dotnet run
```

---

## 🎮 Controls

* **Arrow Keys** → Move the snake
* The snake will continuously move in the current direction

---

## 💀 Game Over

You lose the game if:

* You hit the **walls**
* You collide with **your own body**

When the game ends, you will see:

```
Game Over
```

To play again, simply restart the program:

```bash
dotnet run
```

---

## 🧠 How It Works

This project demonstrates:

* Game loop using `while`
* Real-time keyboard input
* Basic collision detection
* Data structures with `List`

---

## 📁 Project Structure

```
SnakeConsoleGame/
 ├── Program.cs
 ├── SnakeConsoleGame.csproj
 └── README.md
```

---

## 💡 Notes

* Designed to run in a standard terminal
* Works without GPU acceleration
* Ideal for learning game logic fundamentals in C#

---

## 📄 License

This project is open-source and free to use.
