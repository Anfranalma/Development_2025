---
title: "Introduction to R Syntax"
output: html_notebook
---
```{r}
# load libraries
library(dplyr)
library(readr)
```
```{r}
# load data frame
artists <- read_csv('artists.csv')
```
```{r}
# inspect data frame
artists
head(artists)
summary(artists)
```
```{r}
artists %>%
  select(-country,year_founded) %>%
  filter(spotify_monthly_listeners > 20000000, genre != 'Hip Hop') %>%
  arrange(desc(youtube_subscribers))
```