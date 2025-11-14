def is_palindrome(sentence):
    # Initialize two pointers at the start and end
    left, right = 0, len(sentence) - 1
    
    while left < right:
        # Move left pointer forward if not alphanumeric
        if not sentence[left].isalnum():
            left += 1
        # Move right pointer backward if not alphanumeric
        elif not sentence[right].isalnum():
            right -= 1
        # Compare and return False if mismatch
        elif sentence[left].lower() != sentence[right].lower():
            return False
        # Move both pointers inward if characters match
        else:
            left += 1
            right -= 1
    
    # If the loop completes without finding a mismatch, return True
    return True

print(is_palindrome("Draw, O coward!"))
print(is_palindrome("Step on no pets.")) 
print(is_palindrome("Roma ni se conoce sin oro ni se conoce sin amor"))
print(is_palindrome("Yo de todo te doy"))
print(is_palindrome("Ella te dara detalle"))
