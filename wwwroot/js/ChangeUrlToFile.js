function ShowImgPreview(imageUpload, imagePreview)
{
    if(imageUpload.file && imageUpload.file[0])
    {
        var reader = new FileReader();
        reader.onload = function(e)
        {
            $(imagePreview).attr('src',e.target.resuilt);
        }
        reader.readAsDataURL(imageUpload.file[0]);
    }
}