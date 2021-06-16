Feature: Brushing of Teeth

@mytag
Scenario: Successfull Brash
	Given there is toothpaste on the brush
		And mouth is open
		And Mouths Stays Open
	When the back teeth are brushed
		And fronth teeth are brushed
	Then tooth looks clean
		And mouth is fresh
		But the brashes are not damaged
