<?php
session_start();
$page_title = "As16 - Login";
include_once '../user.php';
include_once '../database.php';

$database = new Database();
$db = $database->getConnection();

if (isset($_POST["login"])) {

    $username = $_POST['username'];
    $password = $_POST['password'];

    $username = htmlspecialchars($username);
    $password = htmlspecialchars($password);
    
    $user = new User();
    if ($user->loginUser($db, $username, $password)) {
        $_SESSION["email"] = $username;
        header("Location: ../dashboard");
    } else {
        $error = "Invalid Username or Password";
    }
}

include_once '../header.php' ;
?>

<div class="container" style="background: lightgray; border-radius: 10px; margin-top: 100px;">

    <h1>As16</h1>
    <h2>Login</h2>

    <form action="" method="post">
        <input type="text" class="form-control"
            name="username" placeholder="admin@admin.com"
            required autofocus /><br />
        <input type="password" class="form-control"
            name="password" required /><br />
        <button class="btn btn-lg btn-primary btn-block"
            type="submit" name="login">Login</button>
        <br/>
        <a href="../register">New user? Register!</a>
        <p style="color: red;"><?php if(isset($error)) { echo $error; } ?></p>
    </form>
    
</div>

<?php
include_once '../footer.php';
?>