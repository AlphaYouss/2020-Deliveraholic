export function validateEmail(email){
    const re = /^(([^<>()\\,;:\s@"]+(\.[^<>()\\,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
};

export function validatePassword(password)
{
    if(password.length <= 7)
    {
      return false;
    }
    return true;
};

export function validateNames(name){
    const re = /^[A-Za-z\s+]+.{1,}$/;
    return re.test(String(name));
};

export function validatePhonenumber(phonenumber){
    const re = /^((\+31)|(0031)|0)(\(0\)|)(\d{1,3})(\s||)(\d{8}|\d{4}\s\d{4}|\d{2}\s\d{2}\s\d{2}\s\d{2})$/;
    return re.test(String(phonenumber));
};