from tkinter import *
from tkinter import messagebox

root = Tk()
root.geometry('700x500')
root.config(bg= '#d3f3f5')
root.title('Python Contact Book')
root.resizable(0,0)
contactlist=[
    ['Mauricio Espinoza','2273-8305'],
    ['Roberto Arevalo','2273-0527'],
    ['Edwin Carrillo','2298-4812'],
    ['Mario Calvo','2223-4651'],
    ['Abuela','2242-2467'],
    ['Noel Rodriguez','2228-9874']
]

Name=StringVar()
Number = StringVar()

frame = Frame(root)
frame.pack(side = RIGHT)

scroll = Scrollbar(frame, orient=VERTICAL)
select = Listbox(frame, yscrollcommand=scroll.set, font=('Times new roman',12), bg ='#f0fffc', width=20, height=20, borderwidth=3, relief="groove")
scroll.config (command=select.yview)
scroll.pack(side = RIGHT, fill=Y)
select.pack(side = LEFT, fill=BOTH, expand=1)

def Selected():
    print("hello", len(select.curselection()))
    if len(select.curselection()) == 0:
        messagebox.showerror("Error","Please Select the Name")
    else: 
        return int(select.curselection()[0])
    
def AddContact():
    if Name.get() != "" and Number.get()!="":
        contactlist.append([Name.get(),Number.get()])
        print(contactlist)
        Select_set()
        
        messagebox.showinfo("Confirmation","Successfully Add NEw Contact")

def UpdateDetail():
    if Name.get() and Number.get():
        contactlist[Selected()]=[Name.get(),Number.get()]

        messagebox.showinfo("Confirmation","Successfully Update  Contact")
       
        Select_set()

    elif not(Name.get()) and not(Number.get()) and not(len(select.curselection())==0):
        messagebox.showerror("Error","Please Fill All Fields")
    else:
        if len(select.curselection())==0:
            messagebox.showerror("Error","Please Select the Name")
        else:
            message1 = """To Load the all information  \n
                        select row press Load button"""
            messagebox.showerror("Error",message1)

def Delete_Entry():
    if len(select.curselection())!=0:
        result=messagebox.askyesno('Confirmation','You Want to Delete Contact\n Which you selected')
        if result==True:
            del contactlist[Selected()]
            Select_set()
    else:
        messagebox.showerror("Error", 'Please select the Contact')
 
def VIEW():
    NAME, PHONE = contactlist[Selected()]
    Name.set(NAME)
    Number.set(PHONE)

# exit game window  
def EXIT():
    root.destroy() 
 
def Select_set() :
    contactlist.sort()
    select.delete(0,END)
    for name,phone in contactlist :
        select.insert (END, name)
Select_set()

#PythonGeeks - define buttons labels and entry widget
Label(root, text = 'Name', font=("Times new roman",22,"bold"), bg = 'SlateGray3').place(x= 30, y=20)
Entry(root, textvariable = Name, width=30).place(x= 200, y=30)
Label(root, text = 'Contact No.', font=("Times new roman",20,"bold"),bg = 'SlateGray3').place(x= 30, y=70)
Entry(root, textvariable = Number, width=30).place(x= 200, y=80)
 
Button(root,text=" ADD", font='Helvetica 18 bold',bg='#e8c1c7', command = AddContact, padx=20). place(x= 50, y=140)
Button(root,text="EDIT", font='Helvetica 18 bold',bg='#e8c1c7',command = UpdateDetail, padx=20).place(x= 50, y=200)
Button(root,text="DELETE", font='Helvetica 18 bold',bg='#e8c1c7',command = Delete_Entry, padx=20).place(x= 50, y=260)
Button(root,text="VIEW", font='Helvetica 18 bold',bg='#e8c1c7', command = VIEW).place(x= 50, y=325)
#Button(root,text="RESET", font='Helvetica 18 bold',bg='#e8c1c7', command = EntryReset).place(x= 50, y=390)
Button(root,text="EXIT", font='Helvetica 24 bold',bg='tomato', command = EXIT).place(x= 250, y=470)
 
root.mainloop()