if($(get-module -listavailable sqlserver).count -eq 0)
{
    install-module sqlserver -force
}
else{
    $installed = get-module -listavailable sqlserver
    $installedVersion = $installed.Version.ToString()


    $gallery= Find-Module SqlServer
    $galleryVersion = $gallery.Version.ToString()

    if($galleryVersion -ne $installedVersion)
    {
        update-module sqlserver -force
    }
}