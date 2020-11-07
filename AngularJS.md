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
 - $watch Angular scope object includes $watch event which will be raised whenever a model property is changed.
 
 # AngularJS Events
 - ng-click ng-change
 - simplest example
 
       <body ng-app="myApp">
          <div ng-controller="myController">
              Enter Password: <input type="password" ng-model="password" /> <br />

              <button ng-click="DisplayMessage(password)">Show Password</button
          </div>
          <script>
              var myApp = angular.module('myApp', []);

              myApp.controller("myController", function ($scope, $window) {

                  $scope.DisplayMessage = function (value) {
                      $window.alert(value)
                  }
              });
          </script>
      </body>

# AngularJS Service
- AngularJS services are JavaScript functions for specific tasks, which can be reused throughout the application
## $http Service
- The $http service is used to send or receive data from the remote server using browser's XMLHttpRequest or JSONP.
- eg :

      <body ng-app ="myApp">
          <div>
              <div ng-controller="myController">
                 Response Data: {{data}} <br />
                 Error: {{error}}
              </div>
          </div>
          <script>
              var myApp = angular.module('myApp', []);

              myApp.controller("myController", function ($scope, $http) {

                  var onSuccess = function (data, status, headers, config) {
                      $scope.data = data;
                  };

                  var onError = function (data, status, headers, config) {
                      $scope.error = status;
                  }

                  var promise = $http.get("/demo/getdata");

                  promise.success(onSuccess);
                  promise.error(onError);

              });
          </script>
      </body>
      
 # $log Service
 - AngularJs includes logging service $log, which logs the messages to the browser's console.
 - Have a look on  https://www.tutorialsteacher.com/angularjs/angularjs-log-service
 
 # $window Service 
 - The $window service is a wrapper around window object, so that it will be easy to override, remove or mocked for testing. It is recommended to use $window service in            AngularJS instead of global window object directly.
 
 # AngularJS Filters
 - AngularJS Filters allow us to format the data to display on UI without changing original format.
 
 # AngularJS Modules
 - A module in AngularJS is a container of the different parts of an application such as controller, service, filters, directives, factories etc. It supports separation of          concern using modules.
 - Example: Create a basic Application Module
 
             <!DOCTYPE html>
            <html >
            <head>
                <script src="~/Scripts/angular.js"></script>
            </head>
            <body ng-app="myApp">
                @* HTML content *@
                <script>
                    var myApp = angular.module('myApp', []); 

                </script>
            </body>
            </html>
  - In the above example, the angular.module() method creates an application module, where the first parameter is a module name which is same as specified by ng-app directive.The second parameter is an array of other dependent modules []. In the above example we are passing an empty array because there is no dependency.
  
 # Validation in AngularJS
 - ng-required: Sets required attribute on an input field.
 - ng-minlength: Sets minlength attribute on an input field.
 - see details : https://www.tutorialsteacher.com/angularjs/validation-in-angularjs
 # State Properties
 - Angular includes properties which return the state of form and input controls. The state of the form and control changes based on the user's interaction and validation errors. These built-in properties can be accessed using form name or input control name. To check the form status use formName.propertyName, and to check the state of input control, use formName.inputFieldName.propertyName.
 - see details : https://www.tutorialsteacher.com/angularjs/validation-in-angularjs
 
 # AngularJS Validation CSS Classes
 - ng-valid	Angular will set this CSS class if the input field is valid without errors.
 - see details : https://www.tutorialsteacher.com/angularjs/angularjs-validation-css-classes
 
 # AngularJS Routing
 - see details : https://www.tutorialsteacher.com/angularjs/angularjs-routing
 
 _________________________________________________________________________________________________________________________________
 # Angular js By Udemy 
 
       var myApp = angular.module('myApp',[]); here we put dpendencies inside []
       myApp.controller('mainController',function(){
       });
 
 # Dependency injection
 - in a plain words : passing an object to the function instead of creating one inside it .
 
 # $Scope Service

- Angular js service ar age $ sign thake for eg: $scope

      var myApp = angular.module('myApp',[]); here we put dpendencies inside []
             myApp.controller('mainController',function($scope){
             $scope.name ="test name";
             $scope.getname = function(){
             return 'mahmud';
             }
             console.log($scope);
             });
 
 - There are other services like $log, $filter and other services like messages services 
 - for example ami message service use korte chai tahole message service ar 
 js file ta add korbo then dependencies ar modde message service declae kore dibo as 
message service ar upor dependent like  ['ngMessages']

      var myApp = angular.module('myApp',['ngResource']); here we put dpendencies inside [] so we added resource services
             myApp.controller('mainController',function($scope,$resource){
             $scope.name ="test name";
             $scope.getname = function(){
             return 'mahmud';
             }
             console.log($scope);
             });
 

# Javascript aside

      var things =[1, 
            '2', 
            function (){
            alret("test");
            }
            ];
      things[2]();
      console.log(things);
 
 # Minification :
 - shrinking the size of the file for faser download
 - I definitely shrink javascript and css during deployment 
 - in dependency injection order matters in angular js 
 
 # Data Binding and Directives
 
 ## Scope and Interpolation 
      
      In .js file
      var myApp = angular.module('myApp',[]); 
             myApp.controller('mainController',['$scope',function($scope){

             $scope.name = "Test"
             }]);
             
             
        In html file
       <body ng-app="myApp">
          <div ng-controller="mainController">
              {{name}}
          </div>
      </body>
 
 ## Directives and Two way data bindings 
 - directive : an instrucction to angular js to manipulate dom . fpr eg : add a class or hide this create this etc
 - example of some directives : ng-controller , ng-app , ng-model
 -Two data binding means whatever I am changing in html it is affecting in js and also vice versa 
 
 - example of data binding through directives 
 
        In .js file
            var myApp = angular.module('myApp',[]); 
                   myApp.controller('mainController',['$scope',function($scope){

                   $scope.handle= ""
                   }]);
             
             
        In html file
       <body ng-app="myApp">
          <div ng-controller="mainController">
              <input ype="text" ng-model ="handle"> //using ng model directive we are binding data from js file
          </div>
          <label>his name is :{{handle}}</label>
      </body>
      

## JavaScript aside the event loop
- examples of some of the event call keypress, click , mosueover, change 

# Common Directives 
- ng-if , ng-show , ng-class , ng-repeat , ng-click

# XMLHTTPRequest Object
- thats not a good way to fetch data rather we will use builtin 
angular js http service

# In Angular js get and post data from controller using $HTTP service 
- So we use $http service to get data from controller or backend 
- eg:get 

        var myApp = angular.module('myApp',[]); 
                         myApp.controller('mainController',['$scope','$http',function($scope,$http){

                        $http.get('api path').success(function(result){
                        $scope.rules = result ;
                        
                        });
                       
                         }]);

- post ar khetre view theke data ta nibo then js theke http use kore 
api te data pathabo 


