<?php

namespace App\Controller;

use App\Controller\AppController;

class ArticlesController extends AppController {

    public function index () {;
        $this->loadComponent('Paginator');
        $articles = $this->Paginator->paginate($this->Articles->find());
        $this->set('articles', $artciles);
    }

    public function initialize() : void {        
        parent::initialize();        
        // you could add these to AppController also/instead        
        $this->loadComponent('Paginator');       
        $this->loadComponent('Flash');     
        
    }

    public function add() {        
        $article = $this->Articles->newEmptyEntity(); 
        // empty db table record (row)        
        if($this->request->is('post')) {            
            $article = $this->Articles->patchEntity($article, $this-request->getData());            
            $article->user_id = 1; // not used yet            
            if($this->Articles->save($article)) {                 
                $this->Flash->success('Article has been saved. ');                
                return $this->redirect (['action' => 'index']);            
            }            
            else {                
                $this->Flash->error('Article has NOT been saved. ');            
            }        
        }        
        $this->set('article', $article);     
    }
}
?>