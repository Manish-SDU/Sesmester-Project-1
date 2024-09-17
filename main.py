#A converter for international currency exchange.  
USD_to_GBP = 0.8992
USD_to_EUR = 0.9060
USD_to_JPY = 139.82
USD_to_INR = 83.882
USD_to_SGD = 1.2951
USD_to_DKK = 6.7098

# Symbols
USD_sign = '$'
GBP_sign = '£'
EUR_sign = '€'
JPY_sign = '¥'
INR_sign = '₹'
SGD_sign = 'S$'
DKK_sign = 'kr'

# Repeated text
text = "converts to: "

# Amount to convert
dollars = 1000

# Convertion
pounds = dollars * USD_to_GBP  
euros = dollars * USD_to_EUR
yen = dollars * USD_to_JPY  
rupees = dollars * USD_to_INR
singapore_dollars = dollars * USD_to_SGD
kr = round(dollars * USD_to_DKK, 3)

# Results
print()
print('Today, ' + USD_sign + str(dollars))
print()
print(text + GBP_sign + str(pounds))  
print(text + EUR_sign + str(euros))  
print(text + JPY_sign + str(yen))  
print(text + INR_sign + str(rupees))
print(text + SGD_sign + str(singapore_dollars))  
print(text + DKK_sign + str(kr))
print()