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

//if user is logged in and get's deleted, boot the user of the site
if ($user_role == false) {

    session_destroy();
    header("Location: ../login");
}



include_once '../header.php' ;
include_once '../signedin.php';
?>

<div class="container" style="background: lightgray; border-radius: 10px; margin-top: 20px; padding-bottom: 10px;">
    <table class="table">
        <thead>
            <tr>
                <th>Email</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Address</th>
                <th>Address 2</th>
                <th>City</th>
                <th>State</th>
                <th>Zip Code</th>
                <th>Phone Number</th>
                <?php if($user_role == 'Admin') { echo '<th>Role</th>'; } ?>
                <th>Edit</th>
                <?php if($user_role == 'Admin') { echo '<th>Delete</th>'; } ?>
            </tr>
        </thead>
        <tbody>
        <?php 
            $query = "SELECT * FROM persons";

            $stmt = $db->prepare($query);
            $stmt->execute();
        
            $values = array("email", "fname", "lname", "address", "address2", "city", "state", "zip_code", "phone");

            // Add the 'role' value to if ADMIN role only.
            if($user_role == 'Admin') {
                $values[] = "role";
            }

            while($row = $stmt->fetch(PDO::FETCH_ASSOC) ) {
                
                
                if ($user_role == 'Admin') {
                    if ($row['email'] == $signedin_username) {
                        echo '<tr style="background-color: lightgreen;">';
                    } else {
                        echo '<tr>';
                    }
                   
                    foreach ($values as $val) {
                        echo '<td>' . $row[$val] . '</td>';
                    }   
                   

                    echo '  <td>
                                <a href="../edit/?email=' . $row['email'] . '" class="btn btn-primary" >Edit</a>
                            </td>';
                         
                        if ($row['email'] != $signedin_username) {
                            echo '   <td>
                                <a href="../delete/?email=' . $row['email'] . '" class="btn btn-primary">Delete</a>
                            </td>';
                        }
                        
                       echo ' </tr>';
              
                } else {    
                    if ($row['email'] == $signedin_username) {
                        echo '<tr style="background-color: lightgreen;">';
                    } else {
                        echo '<tr>';
                    }
                   
                    foreach ($values as $val) {
                        echo '<td>' . $row[$val] . '</td>';
                    }   
                    
                    if ($row['email'] == $signedin_username) {
                        echo '<td><a href="../edit/?email=' . $signedin_username . '" class="btn btn-primary">Edit</a></td></tr>';
                    } else {
                        echo '</tr>';
                    }
                }

            }
           
        ?>
        </tbody>
    </table>
    <?php 

        if ($user_role == 'Admin') {
            echo '<a href="../register" class="btn btn-success">Create New User</a>';
        }    
    ?>


</div>

<?php
include_once '../footer.php';
?>