    -- create database;
    DROP DATABASE IF EXISTS kpriceTest;
    CREATE DATABASE IF NOT EXISTS kpriceTest
    CHARACTER SET utf8
    COLLATE utf8_general_ci;
    -- create cars table:
    use kpriceTest;
    drop table if exists carsTest;
    create table if not exists carsTest (
        `id` bigint PRIMARY KEY not null auto_increment,
        `json` text not null,
        `picPath` text not null
    ) character set utf8 collate utf8_general_ci;