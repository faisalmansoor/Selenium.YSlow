param($installPath, $toolsPath, $package, $project)

$plugins = $project.ProjectItems | where-object {$_.Name -eq "Plugins"} 

$firebug = $plugins.ProjectItems | where-object {$_.Name -eq "firebug-2.0.6-fx.xpi"} 
$firebug.Properties.Item("CopyToOutputDirectory").Value = [int]2

$firebug = $plugins.ProjectItems | where-object {$_.Name -eq "yslow-3.1.8-fx.xpi"} 
$firebug.Properties.Item("CopyToOutputDirectory").Value = [int]2
