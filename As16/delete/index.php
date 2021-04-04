<?php
session_start();

if (isset($_SESSION['email'])) {
    $signedin_username = $_SESSION['email'];
} else {
    header("Location: ../login");
}

$page_title = "As16 - Dashboard";
include_once '../user.php';
include_once '../database.php';

$database = new Database();
$db = $database->getConnection();

$user = new User();
$user_role = $user->getRole($db, $signedin_username);

if ($user_role == "Admin") {
    if (isset($_GET['email'])) {
        $email = $_GET["email"];
        if ($email == $signedin_username) {
            header("Location: ../dashboard");
        }
    } else {
        header("Location: ../dashboard");
    }
} else {
    header("Location: ../dashboard");
}

if ($user->checkUser($db, $email)) {
    header("Location: ../dashboard");
}

if (isset($_POST['delete'])) {
    if ($user_role == "Admin") {
        if ($user->deleteUser($db, $email)) {
            header("Location: ../dashboard");
        }
        header("Location: ../dashboard");
    }
}

include_once '../header.php' ;
include_once '../signedin.php';
?>

<div class="container" style="background: lightgray; border-radius: 10px; margin-top: 20px; padding-bottom: 10px;">

    <div>
        <h3>Are you sure you want to delete account of <strong><?php echo $email; ?></strong></h3>
        <form action="" method="post">
            <a href="../dashboard" class="btn btn-warning">Cancel</a>
            <button class="btn btn-danger" name="delete">Delete Account</button>
        </form>
    </div>
    
</div>

<?php
include_once '../footer.php';
?>