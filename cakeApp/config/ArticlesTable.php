<?php

namespace App\Model\Table;
use Cake\ORM\Table;
use Cake\Utility\Text;
use Cake\Event\EventInterface;

class Articlesable extends Table {
    public function initialize (array $config) : void {
        $this->addBehavior('Timestamp');
    }
}
?>