export type LoginForm = {
	email: string;
	password: string;
}

export type LoginResponseDto = {
	tokenType: string,
	accessToken: string,
	expiresIn: number,
	refreshToken: string
}

export type RegisterForm = {
	email: string,
	password: string
}

export type UserInfo = {
	id: string,
	username: string,
	email: string
	name: string,
	surname: string,
	birthDate: string,
	pesel: string,
	phoneNumber: string
}
