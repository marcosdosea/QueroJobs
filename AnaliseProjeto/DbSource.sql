-- MySQL Workbench Synchronization
-- Generated: 2022-08-15 08:35
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: admin

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

ALTER SCHEMA `querojobs`  DEFAULT CHARACTER SET utf8  DEFAULT COLLATE utf8_general_ci ;

ALTER TABLE `querojobs`.`CandidatoCompetencia` 
DROP FOREIGN KEY `fk_Candidato_has_Competencia_Candidato1`,
DROP FOREIGN KEY `fk_Candidato_has_Competencia_Competencia1`;

ALTER TABLE `querojobs`.`Vaga` 
DROP FOREIGN KEY `fk_Vaga_Empresa1`;

ALTER TABLE `querojobs`.`Requisito` 
DROP FOREIGN KEY `fk_Requisito_Vaga1`;

ALTER TABLE `querojobs`.`Diferenciais` 
DROP FOREIGN KEY `fk_Diferenciais_Vaga1`;

ALTER TABLE `querojobs`.`VagaCandidato` 
DROP FOREIGN KEY `fk_Vaga_has_Candidato_Candidato1`;

ALTER TABLE `querojobs`.`Candidato` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `deficiencia` `deficiencia` VARCHAR(100) NULL DEFAULT NULL ;

ALTER TABLE `querojobs`.`Empresa` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `querojobs`.`Competencia` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `querojobs`.`CandidatoCompetencia` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `querojobs`.`Vaga` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `salario` `salario` DECIMAL NULL DEFAULT NULL ;

ALTER TABLE `querojobs`.`Requisito` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `idVaga` `idVaga` INT(11) NOT NULL AFTER `id`;

ALTER TABLE `querojobs`.`Diferenciais` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `idVaga` `idVaga` INT(11) NOT NULL AFTER `id`;

ALTER TABLE `querojobs`.`VagaCandidato` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `querojobs`.`CandidatoCompetencia` 
ADD CONSTRAINT `fk_Candidato_has_Competencia_Candidato1`
  FOREIGN KEY (`idCandidato`)
  REFERENCES `querojobs`.`Candidato` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_Candidato_has_Competencia_Competencia1`
  FOREIGN KEY (`idCompetencia`)
  REFERENCES `querojobs`.`Competencia` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `querojobs`.`Vaga` 
ADD CONSTRAINT `fk_Vaga_Empresa1`
  FOREIGN KEY (`idEmpresa`)
  REFERENCES `querojobs`.`Empresa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `querojobs`.`Requisito` 
ADD CONSTRAINT `fk_Requisito_Vaga1`
  FOREIGN KEY (`idVaga`)
  REFERENCES `querojobs`.`Vaga` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `querojobs`.`Diferenciais` 
ADD CONSTRAINT `fk_Diferenciais_Vaga1`
  FOREIGN KEY (`idVaga`)
  REFERENCES `querojobs`.`Vaga` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `querojobs`.`VagaCandidato` 
DROP FOREIGN KEY `fk_Vaga_has_Candidato_Vaga1`;

ALTER TABLE `querojobs`.`VagaCandidato` ADD CONSTRAINT `fk_Vaga_has_Candidato_Vaga1`
  FOREIGN KEY (`idVaga`)
  REFERENCES `querojobs`.`Vaga` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_Vaga_has_Candidato_Candidato1`
  FOREIGN KEY (`idCandidato`)
  REFERENCES `querojobs`.`Candidato` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
