---
tags:
  - BankingApp
Date Created: 2024-07-15T11:36:00
---

## Notes

- 👑 George 👑
- Joe
- Khadir
- Pai

### Brief

Console app which allows user access to client account
3 different account types = Personal, ISA, Business account

#### Personal Accounts

- [ ] Require an ID
- [ ] Must present Photo ID and Address-based ID
- [ ] Minimum value to open account is £1
- [ ] No charges for owning account
- [ ] Charges may incur if account in red (This means signed number)
- [ ] Includes services like:
	- [ ] Direct Debit
	- [ ] Standing Order
- [ ] One customer can have multiple personal accounts

#### ISA Account

- [ ] Annual APR of 2.75% APR
- [ ] Only one account pp
- [ ] **Must be above 18 and under 40**
- [ ] UK resident
- [ ] 4 Types
	1. Cash ISA
	2. Stocks and shares ISA
	3. Innovative Finance ISA
	4. Lifetime ISA
- [ ] Tax Free
- [ ] 20,000 limit per year

#### Business Account

- [ ] Customer must prove and provide details of an existing business
- [ ] Reject any publicly owned businesses (enterprise, plc, charity, public sector base)


---

### Q & A

Q. Are there any additional security methods?
Use the last four digits of account number?
If you want to access the account give four digits

Q. Only the teller is access account?
Teller is the helper

Q. Usability Standards or guidelines
GBP £
Just supporting the account holder at the front desk
Prompts

Q. Do we need testing?
You can do manual tests

Q. Generic ISA?
APR →
- **Interest of money that has been sitting in the bank for a year**
- **Calculate the interest based on the amount in the account for the whole year (1st April - 31 March)**
- APR = Annual but applied month by month
- APR 5% = “divided up and applied month by month depending on how is in the account”
- APR is proportional to the annual amount
Q. Rules or limits for transactions
- £20,000 limit per year
- **NOT BASED ON BALANCE BUT TOTAL TRANSACTIONS**

Q. Validation rules for transaction (balance rules, debts)
Yes, but not here
Follow the rules given

Q. Do we need a create account?
No just access
But we do this anyways
Needs to use transactions → Ability to add money, transfer and remove

Q. How to verify photo ID, or address-based ID
Yes when setting up account there should be reference ID
When access account reference ID
Validation of ID

Q. Address ID
Don’t need both forms of ID at all times
Take in a council tax reference number

Q. Account in the red
Below £0 even with overdrafts

Q. Bank is for anyone over 18?
Bank is for anyone.
If under 18, parent account is required

Q. Business Yearly Charge
Should be an automatic charge every year
Annually on the day of open account
**How would we do this**

