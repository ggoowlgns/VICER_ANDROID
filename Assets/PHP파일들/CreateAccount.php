<?php

//unity import
$user = $_POST['Input_user'];
$pass = $_POST['Input_pass'];
$Info = $_POST['Input_Info'];

// mysql의 아이디와 비밀번호를 입력해준다. 
$con = mysql_connect("kos2399.cafe24.com","kos2399","study1212") or ("Cannot connect!" .mysql_error());
if(!$con)
	die('Cound not Connect:' . mysql_error());
mysql_select_db("kos2399",$con) or die ("could not load the database" .mysql_error());


$check = mysql_query("SELECT * FROM Account WHERE `user`='".$user."'");  //Account라는 테이블에서 내가 입력한 ID값을 찾겠다. 


// Mysql_num_row()함수는 데이터베이스에서 쿼리를 보내서 나온 레코드의 개수를 알아낼때 쓰임.
// 즉 0이 나왔다는 뜻은 내가 내가 찾는 ID값이 없다는 것이다. 

$numrows = mysql_num_rows($check);    
if ($numrows == 0)
{
	// 정보를 삽입해주는 쿼리문. 
  $Result =  mysql_query("INSERT INTO  `Account` ( `user` , `pass`,`Info`) VALUES ('".$user."' , '".$pass."','".$Info."') ; ");
  
if($Result)
  die("Create Success. \n");
else
  die("Create error. \n");

}

else
{

   die("ID does exist. \n");
}

?>