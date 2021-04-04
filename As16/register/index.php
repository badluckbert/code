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


$pass = true;
if (isset($_POST["register"])) {
    $username = $_POST['username'];
    $password = $_POST['password'];
    $password_confirm = $_POST['password_confirm'];
    $fname = $_POST["fname"];
    $lname = $_POST["lname"];

    $username = htmlspecialchars($username);
    $password = htmlspecialchars($password);
    $password_confirm = htmlspecialchars($password_confirm);
    $fname = htmlspecialchars($fname);
    $lname = htmlspecialchars($lname);

    $errors = array();
 
    if (!preg_match("/\d/", $password)) {
        $errors[] = "Password should contain at least one digit!";
        $pass = false; 
    }
    if (!preg_match("/[A-Z]/", $password)) {
        $errors[] = "Password should contain at least one capital letter!";
        $pass = false; 
    }
    if (!preg_match("/[a-z]/", $password)) {
        $errors[] = "Password should contain at least one small letter!";
        $pass = false; 
    }
    if (!preg_match("/\W/", $password)) {
        $errors[] = "Password should contain at least one special character!";
        $pass = false; 
    }
    if (preg_match("/\s/", $password)) {
        $errors[] = "Password should not contain any white space!";
        $pass = false; 
    }

    if (strlen($password) < 16) {
        $errors[] = "Password must be 16 charaters or more!";
        $pass = false; 
    }

    if ($password != $password_confirm) {
        $errors[] = "Confirm password does not match password!";
        $pass = false;
    }
    $role = 'User';

    if (isset($_POST["role"])) {
        if (isset($user_role)) {
            if ($user_role == "Admin") {
                if (empty($_POST["role"])) {
                    $pass = false;
                    $errors[] = "Please select a role!";
                } else {
                   $role = $_POST["role"]; 
                }
            } else {
                $pass = false;
            }
        }
    }


    if ($pass == true) {
        $user = new User();
        if ($user->checkUser($db, $username)) {
            $user->createUser($db, $role, $username, $password, $fname, $lname); 
           
            if (isset($user_role)) {
                if ($user_role == "Admin") {
                    header("Location: ../dashboard");
                } else {
                    $errors[] = "Log out to create an account!";
                }
            } else {
                $_SESSION["email"] = $username;
                header("Location: ../dashboard");
            }

        } else {
            $errors[] = "Email is in use!";
        }
        
    }

    
}


include_once '../header.php' ;
if (isset($user_role)) {
    if ($user_role == "Admin") {
        include_once '../signedin.php';
    }
}



if (isset($user_role) && $user_role == "Admin") {
    echo '<div class="container" style="background: lightgray; border-radius: 10px; margin-top: 20px; padding: 10px;">';
} else {
    echo '<div class="container" style="background: lightgray; border-radius: 10px; margin-top: 100px; padding: 10px;">';
}


        if (!isset($user_role)) {   
           
            echo '<h1>As16</h1><h2>Register</h2>';
        } else {
            if ($user_role == "Admin") {
                echo '<h1>Create</h1>';
            }
        }
    ?>

    <form action="" method="post">
        <input type="text" class="form-control"
                    name="username" placeholder="admin@admin.com"
                    required autofocus /><br />
        <input type="text" class="form-control"
            name="fname" placeholder="First Name" value="<?php if (isset($fname)){echo $fname;} ?>"/><br />
         <input type="text" class="form-control"
            name="lname" placeholder="Last Name" value="<?php if (isset($lname)){echo $lname;} ?>"/><br />     
        <input type="password" class="form-control"
            name="password" required placeholder="Password"/><br />
        <input type="password" class="form-control"
            name="password_confirm" required placeholder="Confirm Password"/><br />
        <?php 
         if (isset($user_role) && $user_role == "Admin") {
            echo '<select name="role" class="form-control" style="margin-bottom: 10px;">
                <option value="User" selected>User</option>
                <option value="Admin">Admin</option>
            </select>';
        }
        ?>
        <button class="btn btn-lg btn-primary btn-block"
            type="submit" name="register">Register</button>
            <br/>
        <?php 
       
        if (!isset($user_role)) {
            echo '<a href="../login">Already have an account? Login here!</a>';
        }
        ?>
        <p style="color: red;"><?php if (isset($errors)){ 
            foreach ($errors as $error) {
                echo $error . "<br/>";
            }
        } ?></p>
    </form>
    
</div>

<?php
include_once '../footer.php';
?>