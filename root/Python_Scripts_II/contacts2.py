from tkinter import *
from tkinter import ttk
from tkinter import messagebox

# Function to drag the window around
def move_app(event):
    root.geometry(f'+{event.x_root}+{event.y_root}')

# Function to close the app
def close_app():
    root.destroy()

# Root Window Configuration
root = Tk()
root.geometry('800x600')
root.config(bg='#f5f7fa')
root.overrideredirect(True)  # Remove title bar for custom design

# Create rounded window effect (note: it will still be rectangular but this helps)
root.attributes('-transparentcolor', '#f5f7fa')

# Frame to create a custom top bar with a close button
top_bar = Frame(root, bg='#f06292', height=30)
top_bar.pack(fill=X)

# Close (X) Button
close_button = Button(top_bar, text='X', font=('Helvetica', 12, 'bold'), fg='white', bg='#e74c3c', command=close_app, relief=FLAT, padx=5, pady=5)
close_button.pack(side=RIGHT, padx=10, pady=5)

# Make the whole window draggable
top_bar.bind('<B1-Motion>', move_app)

# Contact List
contactlist = [
    ['Mauricio Espinoza', '2273-8305'],
    ['Roberto Arevalo', '2273-0527'],
    ['Edwin Carrillo', '2298-4812'],
    ['Mario Calvo', '2223-4651'],
    ['Abuela', '2242-2467'],
    ['Noel Rodriguez', '2228-9874']
]

Name = StringVar()
Number = StringVar()

# Frames for Layout
left_frame = Frame(root, bg='#f5f7fa', padx=20, pady=20)
left_frame.pack(side=LEFT, fill=BOTH, expand=True)

right_frame = Frame(root, bg='#f0f4f8', padx=20, pady=20)
right_frame.pack(side=RIGHT, fill=Y)

# Scrollable Contact Listbox
scroll = Scrollbar(right_frame, orient=VERTICAL)
select = Listbox(right_frame, yscrollcommand=scroll.set, font=('Helvetica', 12), bg='#e8eaf6', width=30, height=20, borderwidth=3, relief="groove", selectbackground='#f06292', selectforeground='white')
scroll.config(command=select.yview)
scroll.pack(side=RIGHT, fill=Y)
select.pack(side=LEFT, fill=BOTH, expand=1)

# Functions for Contact List Operations
def Selected():
    if len(select.curselection()) == 0:
        messagebox.showerror("Error", "Please Select the Name")
    else:
        return int(select.curselection()[0])

def AddContact():
    if Name.get() != "" and Number.get() != "":
        contactlist.append([Name.get(), Number.get()])
        Select_set()
        messagebox.showinfo("Confirmation", "Successfully Added New Contact")
        Name.set("")
        Number.set("")
    else:
        messagebox.showerror("Error", "Please Fill Both Fields")

def UpdateDetail():
    if len(select.curselection()) != 0:
        contactlist[Selected()] = [Name.get(), Number.get()]
        Select_set()
        messagebox.showinfo("Confirmation", "Successfully Updated Contact")
    else:
        messagebox.showerror("Error", "Please Select a Contact to Edit")

def Delete_Entry():
    if len(select.curselection()) != 0:
        result = messagebox.askyesno('Confirmation', 'Are you sure you want to delete this contact?')
        if result:
            del contactlist[Selected()]
            Select_set()
    else:
        messagebox.showerror("Error", 'Please select a Contact to delete')

def VIEW():
    NAME, PHONE = contactlist[Selected()]
    Name.set(NAME)
    Number.set(PHONE)

def Select_set():
    contactlist.sort()
    select.delete(0, END)
    for name, phone in contactlist:
        select.insert(END, name)

Select_set()

# Customizing the Buttons with a Style
style = ttk.Style()
style.configure('TButton', font=('Helvetica', 14), padding=10, borderwidth=0, relief="flat")
style.map('TButton', background=[('active', '#4caf50')], foreground=[('active', 'white')])
style.configure('Rounded.TButton', relief="flat", borderwidth=0, background="#4caf50", foreground="white", font=('Helvetica', 14, 'bold'), padding=10)

# Labels and Entry Widgets
Label(left_frame, text='Contact Name', font=("Helvetica", 14, "bold"), bg='#f5f7fa').grid(row=0, column=0, sticky=W, pady=10)
Entry(left_frame, textvariable=Name, width=30, font=('Helvetica', 12), bd=2).grid(row=0, column=1, padx=10)

Label(left_frame, text='Contact Number', font=("Helvetica", 14, "bold"), bg='#f5f7fa').grid(row=1, column=0, sticky=W, pady=10)
Entry(left_frame, textvariable=Number, width=30, font=('Helvetica', 12), bd=2).grid(row=1, column=1, padx=10)

# Standard button width for uniformity
button_width = 20

# Buttons with rounded corners, vertically aligned
ttk.Button(left_frame, text="Add Contact", style='Rounded.TButton', command=AddContact).grid(row=2, column=0, columnspan=2, pady=10)
ttk.Button(left_frame, text="Edit Contact", style='Rounded.TButton', command=UpdateDetail).grid(row=3, column=0, columnspan=2, pady=10)
ttk.Button(left_frame, text="Delete Contact", style='Rounded.TButton', command=Delete_Entry).grid(row=4, column=0, columnspan=2, pady=10)
ttk.Button(left_frame, text="View Contact", style='Rounded.TButton', command=VIEW).grid(row=5, column=0, columnspan=2, pady=10)
ttk.Button(left_frame, text="Exit", style='Rounded.TButton', command=close_app).grid(row=6, column=0, columnspan=2, pady=10)

root.mainloop()
