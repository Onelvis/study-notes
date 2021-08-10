
const cases = [
	{
		value: "?ab??a",
		expected: "aabbaa"
	},
	{
		value: "bab??a",
		expected: "NO"
	},
	{
		value: "?a?",
		expected: "aaa"
	},
	{
		value: "a?a",
		expected: "aaa"
	},
	{
		value: "?ab???a",
		expected: "aababaa"
	},
	{
		value: "B?B",
		expected: "bab"
	},
	{
		value: "Abanico",
		expected: "NO"
	},
	{
		value : "????????",
		expected: "aaaaaaaa"
	}
]

cases.forEach(x =>console.log(`${x.value === x.expected} for ${x.value}, returned ${solution(x.value)}, expected ${x.expected}`) );

function solution(input){
	return input;
}