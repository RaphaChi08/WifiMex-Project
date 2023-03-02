-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema DBWifiMex
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema DBWifiMex
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `DBWifiMex` DEFAULT CHARACTER SET utf8 ;
-- -----------------------------------------------------
-- Schema dbwifimex
-- -----------------------------------------------------
USE `DBWifiMex` ;

-- -----------------------------------------------------
-- Table `DBWifiMex`.`Almacen`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DBWifiMex`.`Almacen` (
  `idAlmacen` CHAR(10) NOT NULL,
  `cantProducto` INT(3) NULL,
  `Estatus` TINYINT NULL,
  PRIMARY KEY (`idAlmacen`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DBWifiMex`.`Empleados`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DBWifiMex`.`Empleados` (
  `idEmpleados` CHAR(10) NOT NULL,
  `nomEmpleado` VARCHAR(100) NULL,
  `RFC` VARCHAR(13) NULL,
  `CURP` CHAR(18) NULL,
  `Edad` INT(3) NULL,
  `Direccion` VARCHAR(100) NULL,
  `Telefono` CHAR(10) NULL,
  `Correo` VARCHAR(100) NULL,
  `fechaContratacion` VARCHAR(30) NULL,
  `Rol` VARCHAR(30) NULL,
  `Estatus` TINYINT NULL,
  `Almacen_idAlmacen` CHAR(10) NOT NULL,
  PRIMARY KEY (`idEmpleados`),
  INDEX `fk_Empleados_Almacen1_idx` (`Almacen_idAlmacen` ASC) VISIBLE,
  UNIQUE INDEX `RFC_UNIQUE` (`RFC` ASC) VISIBLE,
  UNIQUE INDEX `CURP_UNIQUE` (`CURP` ASC) VISIBLE,
  CONSTRAINT `fk_Empleados_Almacen1`
    FOREIGN KEY (`Almacen_idAlmacen`)
    REFERENCES `DBWifiMex`.`Almacen` (`idAlmacen`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DBWifiMex`.`Instalaciones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DBWifiMex`.`Instalaciones` (
  `idInstalaciones` CHAR(10) NOT NULL,
  `fechaInstalacion` VARCHAR(30) NULL,
  `Estatus` TINYINT NULL,
  `Empleados_idEmpleados` CHAR(10) NOT NULL,
  PRIMARY KEY (`idInstalaciones`),
  INDEX `fk_Instalaciones_Empleados1_idx` (`Empleados_idEmpleados` ASC) VISIBLE,
  CONSTRAINT `fk_Instalaciones_Empleados1`
    FOREIGN KEY (`Empleados_idEmpleados`)
    REFERENCES `DBWifiMex`.`Empleados` (`idEmpleados`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DBWifiMex`.`Clientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DBWifiMex`.`Clientes` (
  `idClientes` CHAR(10) NOT NULL,
  `RFC` VARCHAR(13) NULL,
  `CURP` CHAR(18) NULL,
  `nomCliente` VARCHAR(50) NULL,
  `Direccion` VARCHAR(100) NULL,
  `Telefono` CHAR(10) NULL,
  `Correo` VARCHAR(100) NULL,
  `Estatus` TINYINT NULL,
  PRIMARY KEY (`idClientes`),
  UNIQUE INDEX `RFC_UNIQUE` (`RFC` ASC) VISIBLE,
  UNIQUE INDEX `CURP_UNIQUE` (`CURP` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DBWifiMex`.`Contratos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DBWifiMex`.`Contratos` (
  `idContrato` CHAR(10) NOT NULL,
  `precioServicio` DOUBLE NULL,
  `inicioContrato` VARCHAR(30) NULL,
  `finContrato` VARCHAR(30) NULL,
  `Estatus` TINYINT NULL,
  `Instalaciones_idInstalaciones` CHAR(10) NOT NULL,
  `Clientes_idClientes` CHAR(10) NOT NULL,
  PRIMARY KEY (`idContrato`),
  INDEX `fk_Contratos_Instalaciones1_idx` (`Instalaciones_idInstalaciones` ASC) VISIBLE,
  INDEX `fk_Contratos_Clientes1_idx` (`Clientes_idClientes` ASC) VISIBLE,
  CONSTRAINT `fk_Contratos_Instalaciones1`
    FOREIGN KEY (`Instalaciones_idInstalaciones`)
    REFERENCES `DBWifiMex`.`Instalaciones` (`idInstalaciones`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Contratos_Clientes1`
    FOREIGN KEY (`Clientes_idClientes`)
    REFERENCES `DBWifiMex`.`Clientes` (`idClientes`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DBWifiMex`.`Proveedores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DBWifiMex`.`Proveedores` (
  `idProveedores` CHAR(10) NOT NULL,
  `nomProveedor` VARCHAR(50) NULL,
  `RFC` VARCHAR(13) NULL,
  `Direccion` VARCHAR(100) NULL,
  `Telefono` CHAR(10) NULL,
  `fechaRegistro` VARCHAR(30) NULL,
  `Estatus` TINYINT NULL,
  PRIMARY KEY (`idProveedores`),
  UNIQUE INDEX `RFC_UNIQUE` (`RFC` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DBWifiMex`.`Productos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DBWifiMex`.`Productos` (
  `codigoBarra` INT(12) NOT NULL,
  `nomProducto` VARCHAR(50) NULL,
  `fechaRegistro` VARCHAR(30) NULL,
  `Estatus` TINYINT NULL,
  `Proveedores_idProveedores` CHAR(10) NOT NULL,
  `Almacen_idAlmacen` CHAR(10) NOT NULL,
  PRIMARY KEY (`codigoBarra`),
  INDEX `fk_Productos_Proveedores_idx` (`Proveedores_idProveedores` ASC) VISIBLE,
  INDEX `fk_Productos_Almacen1_idx` (`Almacen_idAlmacen` ASC) VISIBLE,
  CONSTRAINT `fk_Productos_Proveedores`
    FOREIGN KEY (`Proveedores_idProveedores`)
    REFERENCES `DBWifiMex`.`Proveedores` (`idProveedores`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Productos_Almacen1`
    FOREIGN KEY (`Almacen_idAlmacen`)
    REFERENCES `DBWifiMex`.`Almacen` (`idAlmacen`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
