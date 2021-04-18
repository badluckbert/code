<?php

use \CakeORM\Entity;

class Article extends Entity {
    protected $_accessible = [
        '*' => true,
        'id' => false,
        'slug' => false
    ];
}
?>