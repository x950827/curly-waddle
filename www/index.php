<h2>NotePad for Test</h2>
<form name="testform" enctype="multipart/form-data" method="post">
	<input type="hidden" name="MAX_FILE_SIZE" value="30000000">
	Open File: <input name="userfile" type="file" accept="text/plain">
	<input type="submit" value="Open">
	<br>
	<?
$uploaddir = 'uploads/';
if(move_uploaded_file($_FILES['userfile']['tmp_name'], $_FILES['userfile']['name'])){
	$filename = $_FILES['userfile']['name'];
	$str = htmlentities(file_get_contents("$filename"));
	$_POST['text'] = $str;
}
?>
  Text:
  <br>
  <textarea name="text" cols="180" rows="30" wrap="soft | hard" autofocus required ><?php echo htmlspecialchars($str)?>
  </textarea> 
  <br>
  Name Of Saved File:
	<input type="text" name="NameOfFile" size="30" value=".txt"> 
    <input name="save" type="submit" value="Save"> 

</form>
<?
$text = $_POST['text'];
if(isset($_POST['save'])){
	$nameOfSavedFile = ($_POST['NameOfFile']);
	$names = $nameOfSavedFile + ".txt";
	htmlentities(file_put_contents($nameOfSavedFile, stripslashes ($_POST['text'])));
}
?>