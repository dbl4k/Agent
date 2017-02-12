# Agent
A basic starting framework for creating a tailorable, parameterized agent collection in a single console executable.

## Usage

### Preparation

Write your custom tasks into **Agent.Tasks** project, making sure to inherit from **Common.TaskAgent**.

Alternately, you can add your own task assemblies and reference them in the app.config of the **Agent** executable.

### Execution

From the command line (or using the *Debug > Command Line Arguments* interface, for debugging of course), run your task as follows:

~~~
Agent.exe <TaskName> <param1>=<value1> <param2>=<value2> <param3>=<value3> [...]
~~~

In the example tasks provided, this would work.

~~~
Agent.exe CleanupOldDirs
~~~

If using multiple task assemblies, or even duplicated task names in different namespaces, you can also use a fully resolved type name - i.e. 

~~~
Agent.exe Agent.Tasks.CleanupOldDirs
~~~

.. more coming, that's all for now. :)

- dbl4k 2017
