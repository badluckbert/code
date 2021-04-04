<?php
session_start();

$page_title = "As16 - Register";

include_once '../database.php';
include_once '../user.php';

$database = new Database();
$db = $database->getConnection();


//Check the role if a user is signed in
if (isset($_SESSION['email'])) {
    $signedin_username = $_SESSION['email'];

    $signedin_user = new User();
    $user_role = $signedin_user->getRole($db, $signedin_username);
} 
$user = new User();
if (isset($_GET['email'])) {
    $email = $_GET["email"];
    if (!$user->checkUser($db, $email)) {
        $user_data = $user->getUserData($db, $email);
    } else {
        header("Location: ../dashboard");
    }
    if ($user_role == 'User') {
        if ($email != $signedin_username) {
            header("Location: ../dashboard");
            die;
        }
    }
} else {
    header("Location: ../dashboard");
}

if (isset($_POST["edit"])) {
    $address = htmlspecialchars($_POST['address']);
    $second_address = htmlspecialchars($_POST['address2']);
    $city = htmlspecialchars($_POST['city']);
    $state = htmlspecialchars($_POST["state"]);
    $zip = htmlspecialchars($_POST["zip_code"]);
    $phone = htmlspecialchars($_POST["phone"]);

    var_dump($_POST);

    if (!$user->checkUser($db, $email)) {
        if ($user->editUser($db, $email, $address, $second_address, $city, $state, $zip, $phone)) {
            header("Location: ../dashboard");
        }
        header("Location: ../dashboard");
    } else {
        header("Location: ../dashboard");
    }
    
}

include_once '../header.php' ;
include_once '../signedin.php';

?>
<div class="container" style="background: lightgray; border-radius: 10px; margin-top: 20px; padding: 10px;">

    <h3> You are editing <strong><?php echo $user_data['fname'] . ' ' .  $user_data['lname']; ?></strong> </h3>
    <form action="" method="post">
        <input type="text" class="form-control"
                    name="username"
                    disabled autofocus value="<?php echo $email; ?>"/><br />
    
        <input type="text" class="form-control"
            name="address" placeholder="Address" value="<?php echo $user_data['address'];?>"/><br />
        <input type="text" class="form-control"
            name="address2" placeholder="Second Address" value="<?php echo $user_data['address2'];?>"/><br />     
        <input type="text" class="form-control"
            name="city" required placeholder="City" value="<?php echo $user_data['city'];?>"/><br />
        <input type="text" class="form-control"
            name="state" required placeholder="State" value="<?php echo $user_data['state'];?>"/><br />
        <input type="text" class="form-control"
            name="zip_code" required placeholder="Zip" value="<?php echo $user_data['zip_code'];?>"/><br />
        <input type="text" class="form-control"
            name="phone" required placeholder="Phone" value="<?php echo $user_data['phone'];?>"/><br />


        <button class="btn btn-lg btn-primary btn-block"
            type="submit" name="edit">Save Edit</button>
            <br/>
    </form>
    
</div>

<?php
include_once '../footer.php';
?>