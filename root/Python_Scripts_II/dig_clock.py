import tkinter as tk
import time
from tkinter import Canvas

# Function to update the clock
def update_clock():
    current_time = time.strftime("%H:%M:%S")
    # Clear the previous time
    canvas.delete("clock")
    # Draw the current time at the center of the canvas
    canvas.create_text(canvas.winfo_width() // 2, canvas.winfo_height() // 2, 
                       text=current_time, font=("OCR A Extended", 60, 'bold'), fill="white", tags="clock")
    window.after(1000, update_clock)

# Function to create a rounded rectangle (simulate rounded corners)
def round_rectangle(x1, y1, x2, y2, radius=50, **kwargs):
    points = [x1+radius, y1,
              x1+radius, y1,
              x2-radius, y1,
              x2-radius, y1,
              x2, y1,
              x2, y1+radius,
              x2, y1+radius,
              x2, y2-radius,
              x2, y2-radius,
              x2, y2,
              x2-radius, y2,
              x2-radius, y2,
              x1+radius, y2,
              x1+radius, y2,
              x1, y2,
              x1, y2-radius,
              x1, y2-radius,
              x1, y1+radius,
              x1, y1+radius,
              x1, y1]
    return canvas.create_polygon(points, **kwargs, smooth=True)

# Create the window
window = tk.Tk()
window.title("Astonishing Digital Clock")
window.geometry("450x200")

# Remove title bar
window.overrideredirect(True)

# Allow window dragging
def move_window(event):
    window.geometry(f'+{event.x_root}+{event.y_root}')

# Bind mouse dragging to move the window
window.bind("<B1-Motion>", move_window)

# Define colors for gradient (in RGB format)
color1 = (0, 0, 64)     # Dark blue
color2 = (0, 255, 255)  # Cyan

# Make the window resizable
window.resizable(True, True)

# Create the canvas
canvas = Canvas(window, width=500, height=300, highlightthickness=0)
canvas.pack(fill="both", expand=True)

# Create the rounded rectangle for the background
round_rectangle(0, 0, 450, 200, radius=50, fill="#002040")

# Create the gradient
for i in range(300):
    r = int(color1[0] + (color2[0] - color1[0]) * (i / 300))
    g = int(color1[1] + (color2[1] - color1[1]) * (i / 300))
    b = int(color1[2] + (color2[2] - color1[2]) * (i / 300))
    color = f'#{r:02x}{g:02x}{b:02x}'
    canvas.create_line(0, i, 500, i, fill=color)

# Create a close button to exit the app
close_button = tk.Button(window, text="X", font=("OCR A Extended", 12), bg="red", fg="white", command=window.destroy, bd=0)
close_button.place(x=420, y=10)

# Set the window to always be on top
window.attributes("-topmost", True)

# Start the clock
update_clock()

# Run the app
window.mainloop()
