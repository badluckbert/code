<?php

namespace App\Controller;

//use App\Controller\AppController;

class ArticlesController extends AppController {

    public function index () {
        die('hey');
        $this->loadComponent('Paginator');
        $articles = $this->Paginator->paginate($this->Articles->find());
        $this->set('articles', $artciles);
    }
}
?>