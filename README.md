# StackMaker
Script bao gồm các class: 
+ Player
+ PlayerMove
+ BrickProcess
+ UnbrickProcess
+ EndGame


Các Class Manager:
+ LevelManager
+ UIManager
+ GameManager


Class Player được gán vào Player, gọi đến 2 class PlayerMove và BrickProcess. 

Class PlayerMove chứa các hàm:
+ GetPositionTarget(): Tìm điểm cần di chuyển đến
+ MoveToTargetPosition(): Di chuyển Player đến điểm đích

Class BrickProcess chứa các hàm:
+ IsBirck(): Kiểm tra vị trí hiện tại có phải BrickWall không
+ IsUnBrick(): Kiểm tra vị trí hiện tại có phải UnBrickWall không
+ AddBrick(): Thêm Brick vào chân Player
+ RemoveBrick(): Loại bỏ Brick từ chân Player
+ ClearBrick(): Xóa toàn bộ Brick từ chân Player


Class UnBrickProcess để xử lý vùng UnBrickWall khi Player đi qua, sẽ thay đổi nền hiện tại thành Brick:

Class EndGame thực hiện Particle khi Player đến điểm đích

Class GenerateMap đang được update để sinh ra map ngẫu nhiên
