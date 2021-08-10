export const CalculateAge = (birthday: Date): number => {
	let ageInMilliseconds = Date.now() - birthday.getTime();
	let ageAsDate = new Date(ageInMilliseconds);
	return Math.abs(ageAsDate.getUTCFullYear() - 1970);
};
