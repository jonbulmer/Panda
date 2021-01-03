CREATE Table [dbo].[owid_country]
(
	[Id]	INT	IDENTITY (1,1) NOT NULL,
    [continent] VARCHAR(256) NOT NULL,
    [location] VARCHAR(256) NOT NULL, 
    [population] DECIMAL(16,4) NOT NULL,
    [population_density]  DECIMAL(16,4) NOT NULL,
    [median_age] DECIMAL(16,4) NOT NULL,
    [aged_65_older]  DECIMAL(16,4) NOT NULL,
    [aged_70_older]  DECIMAL(16,4) NOT NULL,
    [gdp_per_capita]  DECIMAL(16,4) NOT NULL,
    [extreme_poverty]  DECIMAL(16,4) NOT NULL,
    [cardiovasc_death_rate]  DECIMAL(16,4) NOT NULL,
    [diabetes_prevalence]  DECIMAL(16,4) NOT NULL,
    [female_smokers]  DECIMAL(16,4) NOT NULL,
    [male_smokers]  DECIMAL(16,4) NOT NULL,
    [hospital_beds_per_thousand]  DECIMAL(16,4) NOT NULL,
    [life_expectancy]  DECIMAL(16,4) NOT NULL,
    [human_development_index]  DECIMAL(16,4) NOT NULL
);
