import periodictable

def get_element_info(symbol):
    if not periodictable.elements.symbol(symbol):
        print("Invalid element symbol.")
        return
    element = periodictable.elements.symbol(symbol)
    print(f"Element: {element.name}")
    print(f"Symbol: {element.symbol}")
    print(f"Atomic Number: {element.number}")
    print(f"Atomic Mass: {element.mass:.2f} u")
    print(f"Density: {element.density:.2f} g/cm��")
    # print(f"Melting Point: {element.melting_point:.2f} K")
    # print(f"Boiling Point: {element.boiling_point:.2f} K")

element_symbol = input("Enter the symbol of the element: ")
get_element_info(element_symbol)