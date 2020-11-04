# What is AngularJS?
- AngularJS is a client side JavaScript MVC framework to develop a dynamic web application.
- AngularJS changes static HTML to dynamic HTML. simplest Eg :

      <head>
            <script src="~/Scripts/angular.js"></script>
        </head>
        <body ng-app>
            Enter Your Name: <input type="text" ng-model="name" /> <br />
            Hello <label ng-bind="name"></label>
        </body>

# Setup AngularJS Development Environment
- https://www.tutorialsteacher.com/angularjs/angularjs-development-environment

# Directives 
- ng app, ng model ,etc  

- The ng-app directive initializes AngularJS
- The ng-init directive can be used to initialize variables in AngularJS application.
- there are other directives too see details https://www.tutorialsteacher.com/angularjs/angularjs-directives
                      
                      
# AngularJS Controller
- The ng-controller directive is used to specify a controller in HTML element, which will add behavior or maintain the data in that HTML element and its child elements.
simplest eg of controller. 

      <body ng-app="myNgApp">
          <div ng-controller="myController">
              {{message}}
          </div>
          <script>
              var ngApp = angular.module('myNgApp', []);

              ngApp.controller('myController', function ($scope) {
                  $scope.message = "Hello World!";        
              });
          </script>
      </body>
      
 # Scope in AngularJS
 - The $scope is glue between a controller and view (HTML). It transfers data from the controller to view and vice-versa.
