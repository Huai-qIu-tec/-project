CREATE DATABASE medicineinfo;
use medicineinfo;
/*
此表存放用户的基本信息
param descripe:
    用户编号	user_id
    用户姓名	user_name
    性别	    user_sex
    年龄	    user_age
    密码	    user_password
    证件类型	id_type
    证件号码	id_no
    手机号	    user_mobilephone
    用户地址	user_address

*/
drop table if EXISTS user;
create table user(
    user_id INT NOT NULL AUTO_INCREMENT,
    user_name VARCHAR(50) NOT NULL,
    user_sex VARCHAR(2) default '男',
    user_age int CHECK(user_age > 0),
    user_password VARCHAR(64) NOT NULL,
    id_type VARCHAR(10) NOT NULL,
    id_no VARCHAR(18) NOT NULL,
    user_phone VARCHAR(11) NOT NULL,
    user_address VARCHAR(80),
    user_redit INT NOT NULL DEFAULT 100,
    PRIMARY KEY ( user_id ) 
);

/*
doctor表存放医生的相关信息,
param:
    医生编号	doctor_id
    科室编号	dept_code
    医生姓名	doctor_name
    性别	    doctor_sex
    年龄	    doctor_age
    密码	    doctor_password
    手机号	    user_phone
    医生学历	doctor_education
    医生职称	doctor_title_level
    挂号费	    dexper
    擅长治疗疾病	speciality_diease
    擅长介绍	speciality


*/
drop table if EXISTS doctor;
create table doctor(
    doctor_id INT NOT NULL AUTO_INCREMENT,
    dept_code INT NOT NULL,
    doctor_name VARCHAR(50) NOT NULL,
    doctor_sex VARCHAR(2) NOT NULL DEFAULT '男',
    doctor_age INT CHECK(doctor_age > 0),
    doctor_password VARCHAR(64) NOT NULL,
    doctor_phone VARCHAR(11) NOT NULL,
    doctor_education VARCHAR(50) NOT NULL,
    doctor_title_level VARCHAR(20) NOT NULL,
    dexper DOUBLE NOT NULL,
    speciality_diease VARCHAR(50) NOT NULL,
    speciality VARCHAR(200) NOT NULL,
    PRIMARY KEY(doctor_id)
);

/*
dept表存放科室的相关信息
param:
    科室编号	dept_id
    科室名	    dept_name
*/
drop table if EXISTS dept;
create table dept(
    dept_id INT NOT NULL AUTO_INCREMENT,
    dept_name VARCHAR(40) NOT NULL,
    PRIMARY KEY(dept_id)
);

/*
appointment表存放医生排班信息,用于按照排班时间或者科室排班查询以及按照疾病查询排班医生
    排班编号	appointment_id      主键
    医生编号	doctor_id           外键
    出诊时间	date_of_work
    最大可约数	max_of_appointment
    已预约人数	num_of_appointment
    擅长疾病名	diease_name
    医生状态	doctor_status
*/
drop table if EXISTS appointment;
create table appointment(
    appointment_id INT NOT NULL PRIMARY KEY,
    doctor_id INT NOT NULL AUTO_INCREMENT,
    date_of_work DATETIME NOT NULL,
    max_of_appointment INT NOT NULL,
    num_of_appointment INT NOT NULL,
    doctor_status INT NOT NULL,
    FOREIGN KEY (doctor_id) REFERENCES doctor (doctor_id)
);

/*
此表存放用户的预约信息
params:
    预约编号	order_id
    科室编号	dept_id
    医生编号	doctor_id
    用户编号	user_id
    排版编号	order_id
    预约日期	order_time
    预约时间段	order_period
    预约状态	order_status
*/
drop table if EXISTS orderinfo;
create table orderinfo(
    order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    dept_id INT NOT NULL,
    doctor_id INT NOT NULL,
    user_id INT NOT NULL,
    order_time DATETIME NOT NULL,
    order_status INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user (user_id)
);

/*
此表存放信息
params:
    预约编号	order_id
    科室编号	dept_id
    医生编号	doctor_id
    用户编号	user_id
    排版编号	order_id
    预约日期	order_time
    预约时间段	order_period
    预约状态	order_status
*/

drop table if EXISTS PhysicalExamination;
CREATE TABLE PhysicalExamination(
    examination_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    examination_time DATETIME NOT NULL,
    context VARCHAR(100) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user (user_id)
);


/*----------------------------
            插入user表
*/
insert into user(user_id, user_name, user_sex ,user_age ,user_password ,id_type ,id_no ,user_phone ,user_address, user_redit)
values(1, '张岩', '男', 20, '123456', '身份证', '41302620010816033X', '17302590089', '江苏省南京市', 100);

insert into user(user_id, user_name, user_sex ,user_age ,user_password ,id_type ,id_no ,user_phone  ,user_address, user_redit)
values(2, '张帅', '男', 21, '123456', '身份证', '31302620010816033X', '17302590088', '江苏省南京市', 100);

insert into user(user_id, user_name, user_sex ,user_age ,user_password ,id_type ,id_no ,user_phone  ,user_address, user_redit)
values(3, '陶一言', '女', 19, '123456', '身份证', '21302620010816033X', '17302590087', '江苏省南京市', 100);

insert into user(user_id, user_name, user_sex ,user_age ,user_password ,id_type ,id_no ,user_phone ,user_address, user_redit)
values(4, '王译', '男', 22, '123456', '身份证', '11302620010816033X', '17302590080', '江苏省南京市', 100);

insert into user(user_id, user_name, user_sex ,user_age ,user_password ,id_type ,id_no ,user_phone ,user_address, user_redit)
values(5, '刘正坤', '男', 23, '123456', '身份证', '413026200108150341', '17302590086', '江苏省南京市', 100);

insert into user(user_id, user_name, user_sex ,user_age ,user_password ,id_type ,id_no ,user_phone ,user_address, user_redit)
values(6, '刘正', '男', 18, '123456', '身份证', '41152520010816033X', '17302590085', '江苏省南京市', 100);


/*----------------------------
            插入doctor表
*/
insert into doctor(doctor_id, dept_code, doctor_name, doctor_sex, doctor_age, doctor_password, doctor_phone, doctor_education, doctor_title_level, dexper, speciality_diease, speciality)
values(1, 1, '杨成峰', '男', 28, '123456', '15850537350', '医学博士', '主任医师', 10.0, '心绞痛、心肌梗死、冠心病诊治',
 '江苏省中医院心内科主任,医学博士,主任医师,教授,博士生导师。已从事心内科临床、教学及科研工作30余年。对冠心病、高血压、高脂血症、心律失常以及心力衰竭等各种心血管疾病的现代综合治疗具有丰富的临床经验,擅长针对不同患者制定合理的个体化中西医结合治疗方案,特别重视与强调疾病的预防。');

insert into doctor(doctor_id, dept_code, doctor_name, doctor_sex, doctor_age, doctor_password, doctor_phone, doctor_education, doctor_title_level, dexper, speciality_diease, speciality)
values(2, 1, '杨阳', '男', 28, '123456', '15850537351', '医学博士', '主任医师', 10.0, '心绞痛、心肌梗死等',
 '江苏省中医院心内科主任,医学博士,副主任医师,教授,博士生导师。已从事心内科临床、教学及科研工作30余年。对冠心病、高血压、高脂血症、心律失常以及心力衰竭等各种心血管疾病的现代综合治疗具有丰富的临床经验,擅长针对不同患者制定合理的个体化中西医结合治疗方案,特别重视与强调疾病的预防。');

insert into doctor(doctor_id, dept_code, doctor_name, doctor_sex, doctor_age, doctor_password, doctor_phone, doctor_education, doctor_title_level, dexper, speciality_diease, speciality)
values(3, 5, '李星龙', '男', 40, '123456', '15850371222', '医学博士', '副主任医师', 5.0, '湿疹、荨麻诊等',
 '江苏省中医院心内科主任,医学博士,副主任医师,副教授,硕士生导师。已从事心内科临床、教学及科研工作30余年。对冠心病、高血压、高脂血症、心律失常以及心力衰竭等各种心血管疾病的现代综合治疗具有丰富的临床经验,擅长针对不同患者制定合理的个体化中西医结合治疗方案,特别重视与强调疾病的预防。');

insert into doctor(doctor_id, dept_code, doctor_name, doctor_sex, doctor_age, doctor_password, doctor_phone, doctor_education, doctor_title_level, dexper, speciality_diease, speciality)
values(4, 5, '张耀辉', '男', 32, '123456', '17202590091', '医学博士', '副主任医师', 5.0, '银屑病、痤疮等',
 '江苏省中医院心内科主任,医学博士,副主任医师,副教授,硕士生导师。已从事心内科临床、教学及科研工作30余年。对冠心病、高血压、高脂血症、心律失常以及心力衰竭等各种心血管疾病的现代综合治疗具有丰富的临床经验,擅长针对不同患者制定合理的个体化中西医结合治疗方案,特别重视与强调疾病的预防。');

insert into doctor(doctor_id, dept_code, doctor_name, doctor_sex, doctor_age, doctor_password, doctor_phone, doctor_education, doctor_title_level, dexper, speciality_diease, speciality)
values(5, 1, '李倩', '女', 29, '123456', '15903755531', '医学博士', '副主任医师', 5.0, '风湿性心脏病等',
 '江苏省中医院心内科主任,医学博士,副主任医师,副教授,硕士生导师。已从事心内科临床、教学及科研工作30余年。对冠心病、高血压、高脂血症、心律失常以及心力衰竭等各种心血管疾病的现代综合治疗具有丰富的临床经验,擅长针对不同患者制定合理的个体化中西医结合治疗方案,特别重视与强调疾病的预防。');
insert into doctor(doctor_id, dept_code, doctor_name, doctor_sex, doctor_age, doctor_password, doctor_phone, doctor_education, doctor_title_level, dexper, speciality_diease, speciality)
values(6, 1, '张扬', '女', 32, '123456', '15903755532', '医学博士', '副主任医师', 5.0, '风湿性心脏病等',
 '江苏省中医院心内科主任,医学博士,副主任医师,副教授,硕士生导师。已从事心内科临床、教学及科研工作30余年。对冠心病、高血压、高脂血症、心律失常以及心力衰竭等各种心血管疾病的现代综合治疗具有丰富的临床经验,擅长针对不同患者制定合理的个体化中西医结合治疗方案,特别重视与强调疾病的预防。');
insert into doctor(doctor_id, dept_code, doctor_name, doctor_sex, doctor_age, doctor_password, doctor_phone, doctor_education, doctor_title_level, dexper, speciality_diease, speciality)
values(7, 2, '陶一言', '男', 32, '123456', '15903755533', '医学博士', '副主任医师', 5.0, '高血压疾病等',
 '江苏省中医院心内科主任,医学博士,副主任医师,副教授,硕士生导师。已从事心内科临床、教学及科研工作30余年。对冠心病、高血压、高脂血症、心律失常以及心力衰竭等各种心血管疾病的现代综合治疗具有丰富的临床经验,擅长针对不同患者制定合理的个体化中西医结合治疗方案,特别重视与强调疾病的预防。');


/*-------------------------
        插入科室表
*/
insert into dept(dept_id, dept_name) values(1, '心内科');
insert into dept(dept_id, dept_name) values(2, '高血压科');
insert into dept(dept_id, dept_name) values(3, '消化科');
insert into dept(dept_id, dept_name) values(4, '内分泌科');
insert into dept(dept_id, dept_name) values(5, '皮肤科');


/*-------------------------
        插入排班表
*/
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(1, 1, '2022-05-08 08:00', 20, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(2, 1, '2022-05-09 08:00', 10, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(3, 2, '2022-05-08 14:00', 10, 8, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(4, 3, '2022-05-08 14:00', 10, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(5, 4, '2022-05-08 08:00', 10, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(6, 5, '2022-5-8 8:00', 10, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(7, 6, '2022-5-8 8:00', 15, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(8, 7, '2022-5-8 8:00', 15, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(8, 7, '2022-5-8 8:00', 15, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(9, 1, '2022-5-9 8:00', 15, 10, 1);
insert into appointment(appointment_id, doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status) values(10, 1, '2022-5-9 14:00', 15, 10, 1);

/*-------------------------
        插入预约表
*/
insert into orderinfo(order_id, dept_id, doctor_id, user_id, order_time, order_status) values(1, 1, 1, 1, '2022-05-08 08:00', 1);
insert into orderinfo(order_id, dept_id, doctor_id, user_id, order_time, order_status) values(2, 1, 1, 2, '2022-05-08 08:00', 1);
insert into orderinfo(order_id, dept_id, doctor_id, user_id, order_time, order_status) values(3, 1, 1, 3, '2022-05-08 08:00', 1);
insert into orderinfo(order_id, dept_id, doctor_id, user_id, order_time, order_status) values(4, 1, 1, 4, '2022-05-08 08:00', 1);
insert into orderinfo(order_id, dept_id, doctor_id, user_id, order_time, order_status) values(5, 1, 1, 5, '2022-05-08 08:00', 1);

/* 查询当前共有多少条用户记录*/
SELECT MAX(user_id) from user;

/* 查询doctor_id, doctor_name, doctor_title_level, speciality*/
SELECT doctor_id, doctor_name, doctor_title_level, speciality_diease from doctor where dept_code in (SELECT dept_id from dept where dept_name = "心内科") ORDER BY doctor_id;

SELECT doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status from appointment where doctor_id in (SELECT doctor_id from doctor where dept_code in (SELECT dept_id from dept where dept_name = "心内科")) ORDER BY doctor_id;

SELECT doctor.doctor_id, doctor.dept_code, doctor.doctor_name, doctor.doctor_title_level, doctor.speciality_diease, 
        appointment.date_of_work, appointment.max_of_appointment, appointment.num_of_appointment, appointment.doctor_status
    FROM doctor INNER JOIN appointment ON doctor.doctor_id = appointment.appointment_id
    WHERE doctor.dept_code in (SELECT dept_id from dept where dept_name = '心内科');


SELECT doctor.doctor_id, doctor.dept_code, doctor.doctor_name, doctor.doctor_title_level, doctor.speciality_diease, 
        appointment.date_of_work, appointment.max_of_appointment, appointment.num_of_appointment, appointment.doctor_status
    FROM doctor INNER JOIN appointment ON doctor.doctor_id = appointment.appointment_id
    WHERE (doctor.dept_code in (SELECT dept_id from dept where dept_name = '心内科') AND 
    (appointment.date_of_work = '2022-05-09 08:00' OR appointment.date_of_work = '2022-05-09 14:00')) ;


SELECT doctor_id, doctor_name, doctor_title_level, speciality_diease from doctor where dept_code in (SELECT dept_id from dept where dept_name = "心内科") ;

/*查询某天某科室的所有在班可预约信息*/
SELECT * FROM(SELECT * FROM appointment WHERE doctor_id in (SELECT doctor_id from appointment WHERE
    appointment.date_of_work BETWEEN '2022-05-08' and '2022-05-9') 
    AND appointment.date_of_work BETWEEN '2022-05-08' and '2022-05-9') as temp
    WHERE doctor_id in (SELECT doctor_id FROM doctor WHERE dept_code in (SELECT dept_id from dept where dept_name = '心内科'));

/*查询某天某科室在班医生信息*/
SELECT * FROM doctor WHERE doctor_id in (SELECT doctor_id from appointment WHERE
    appointment.date_of_work BETWEEN '2022-05-08' and '2022-05-9') AND
    doctor_id in (SELECT doctor_id FROM doctor WHERE dept_code in (SELECT dept_id from dept where dept_name = '心内科'));

SELECT appointment_id,doctor_id,date_of_work,max_of_appointment,num_of_appointment,doctor_status FROM appointment;

SELECT doctor.doctor_name, doctor.doctor_title_level, doctor.doctor_education, doctor.dexper, doctor.speciality_diease, doctor.speciality
FROM doctor
WHERE doctor_id = 1;

SELECT MAX(order_id) from orderinfo;

insert into orderinfo(order_id, dept_id, doctor_id, user_id, order_time, order_status) values(6, 1, 1, 1, '2022/05/08 08:00', 1);

UPDATE appointment SET num_of_appointment = num_of_appointment+1 WHERE doctor_id = 1 AND  date_of_work = '2022/05/09 08:00';

/* 
    查询预约记录
*/



SELECT  * FROM (SELECT * FROM orderinfo INNER JOIN doctor USING(doctor_id)) as temp WHERE user_id in (
    SELECT user_id FROM user WHERE user_phone = '17302590089'
);
SELECT * FROM orderinfo INNER JOIN doctor USING(doctor_id);

DELETE FROM orderinfo WHERE  order_time = '2022-05-08 08:00' AND user_id in (
    SELECT user_id FROM user WHERE user_phone = '17302590089'
);

UPDATE appointment SET num_of_appointment = num_of_appointment-1 WHERE date_of_work = '2022/05/09 08:00' AND doctor_id in (
    SELECT doctor_id FROM doctor WHERE doctor_name = '杨成峰'
);

SELECT 1 FROM orderinfo WHERE user_id = 1 AND order_time = '2022-05-08 08:00:00' LIMIT 1;