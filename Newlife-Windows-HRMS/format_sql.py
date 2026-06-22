import re
from datetime import datetime

file_path = r'D:\ukjobprojects\hrms\attendance_data.sql'

with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

def replace_date_time(match):
    date_str = match.group(1)
    status_str = match.group(2)
    time_str = match.group(3)
    
    # Parse date MM/DD/YYYY
    dt = datetime.strptime(date_str, '%m/%d/%Y')
    new_date = dt.strftime('%Y-%m-%d 00:00:00')
    
    # Parse time HH:MM AM/PM
    tm = datetime.strptime(time_str, '%I:%M %p')
    new_time = tm.strftime('%H:%M:%S')
    
    return f"'{new_date}', '{status_str}', '{new_time}'"

# Pattern matches: 'MM/DD/YYYY', 'STATUS', 'HH:MM AM/PM'
# INSERT INTO Att_Details ... VALUES ('A00001', 'EMP001', '04/01/2026', 'IN', '08:00 AM');
pattern = r"'(\d{2}/\d{2}/\d{4})',\s*'([^']+)',\s*'(\d{2}:\d{2} [AP]M)'"

new_content = re.sub(pattern, replace_date_time, content)

with open(file_path, 'w', encoding='utf-8') as f:
    f.write(new_content)

print('SQL file updated successfully.')
