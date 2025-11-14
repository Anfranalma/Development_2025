import os
import shutil

def merge_folders(source_folder, destination_folder):
    """
    Merge files and subfolders from source_folder into destination_folder.
    """
    for root, dirs, files in os.walk(source_folder):
        # Calculate the relative path of the current directory from the source folder
        relative_path = os.path.relpath(root, source_folder)
        
        # Determine the corresponding directory in the destination folder
        dest_dir = os.path.join(destination_folder, relative_path)
        
        # Create the directory in the destination folder if it does not exist
        if not os.path.exists(dest_dir):
            print(f"Creating directory: {dest_dir}")
            os.makedirs(dest_dir)
        
        # Copy each file from the source to the destination
        for file in files:
            src_file = os.path.join(root, file)
            dest_file = os.path.join(dest_dir, file)
            
            # Only copy the file if it does not exist in the destination
            if not os.path.exists(dest_file):
                print(f"Copying file: {src_file} to {dest_file}")
                shutil.copy2(src_file, dest_file)  # Use copy2 to preserve metadata
            else:
                print(f"File already exists, skipping: {dest_file}")

if __name__ == "__main__":
    # Input the source and destination folder paths
    source_folder = input("Enter the path to the source folder (folder 2): ")
    destination_folder = input("Enter the path to the destination folder (folder 1): ")
    
    # Check if both folders exist
    if os.path.exists(source_folder) and os.path.exists(destination_folder):
        merge_folders(source_folder, destination_folder)
        print("\nMerge complete!")
    else:
        print("One or both of the folder paths do not exist.")
