<?php
session_start();
$sql="select DISTINCT x.Ci,y.*,z.* from  academico.datosest y, academico.datosuniv z, academico.pagosrealizados x ";
$sql.="where y.Ci=z.Ci AND z.Ci=x.Ci AND ";
$sql.="y.Ci="."123456";
$resultadoR=mysqli_query($con,$sql);
$filaR=mysqli_fetch_array($resultadoR,MYSQLI_ASSOC);


$sql="select * from academico.archivosAdj ";
$sql.="where Ci="."123456";
$resultadoAdj=mysqli_query($con,$sql);
$filaAdj=mysqli_fetch_array($resultadoAdj);
?>