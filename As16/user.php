<?php
class User {

    private $table_name = "persons";

    public function createUser($db, $role, $username, $password, $fname, $lname) {
        
        $salt = MD5(microtime(true));
        $hash = MD5($password . $salt);
          
        $query = "INSERT INTO " . $this->table_name . "
            SET role=:role, email=:username, password_salt=:salt, password_hash=:hash, fname=:fname, lname=:lname";

        $stmt = $db->prepare($query);  

        $stmt->bindParam(":role", $role);
        $stmt->bindParam(":username", $username);
        $stmt->bindParam(":salt", $salt);
        $stmt->bindParam(":hash", $hash);
        $stmt->bindParam(":fname", $fname);
        $stmt->bindParam(":lname", $lname);

        if($stmt->execute()){
            return true;
        }else{
            return false;
        }

    }
    
    public function checkUser($db, $username){

        $query = "SELECT * FROM " . $this->table_name . "
            WHERE email=:username LIMIT 1";

        $stmt = $db->prepare($query);
        $stmt->bindParam(":username", $username);
        $stmt->execute();
        
        $num = $stmt->rowCount();
        if ($num == 1) {
            return false;
        }
        return true;

    }
    
    public function loginUser($db, $username, $password) {
        
        $query =  "SELECT password_hash, password_salt FROM " . $this->table_name . "
        WHERE email=:username LIMIT 1";

        $stmt = $db->prepare($query);
        $stmt->bindParam(':username', $username);
        $stmt->execute();
      
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
      
        // Do we have any rows with that user?
        if ($stmt->rowCount() > 0) {
            // Grab the salt and hash
            $salt = $row['password_salt'];
            $saved_hash = $row['password_hash'];
            $hash = MD5($password . $salt);
            if ($saved_hash == $hash){
                return true;
            }   
        }
        return false;
    }

    public function getRole($db, $username) {
        
        $query =  "SELECT role FROM " . $this->table_name . "
        WHERE email=:username LIMIT 1";

        $stmt = $db->prepare($query);
        $stmt->bindParam(':username', $username);
        $stmt->execute();
      
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
      
        // Do we have any rows with that user?
        if ($stmt->rowCount() > 0) {
            // Grab the salt and hash
            $role = $row['role'];
            return $role; 
        }
        return false;
    }

    public function deleteUser($db, $username){
    
        $query =  "DELETE FROM " . $this->table_name . "
        WHERE email=:username LIMIT 1";

        $stmt = $db->prepare($query);
        $stmt->bindParam(':username', $username);

        if($stmt->execute()){
            return true;
        }else{
            return false;
        }
    }
    public function editUser($db, $username, $address, $second_address, $city, $state, $zip, $phone) {
        $query =  "UPDATE " . $this->table_name . "
            SET
                address=:address,
                address2=:second_address,
                city=:city,
                state=:state,
                zip_code=:zip,
                phone=:phone
            WHERE
                email=:username";

        $stmt = $db->prepare($query);
        $stmt->bindParam(':address', $address);
        $stmt->bindParam(':second_address', $second_address);
        $stmt->bindParam(':city', $city);
        $stmt->bindParam(':state', $state);
        $stmt->bindParam(':zip', $zip);
        $stmt->bindParam(':phone', $phone);
        $stmt->bindParam(':username', $username);
        

        if($stmt->execute()){
            return true;
        }else{
            return false;
        }
    }
    public function getUserData($db, $username) {
        
        $query =  "SELECT * FROM " . $this->table_name . "
        WHERE email=:username LIMIT 1";

        $stmt = $db->prepare($query);
        $stmt->bindParam(':username', $username);
        $stmt->execute();
      
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
      
        // Do we have any rows with that user?
        if ($stmt->rowCount() > 0) {
            // Grab the salt and hash
            return $row; 
        }
        return false;
    }
} 
?>