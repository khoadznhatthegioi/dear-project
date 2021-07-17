# dear-project
Những thứ cần chú ý: 
- Trong folder SScripts (theo thứ tự alphabet):
  + DisplayInventory.cs
  + InventoryDisappear.cs (còn cồng kềnh và vô duyên)
  + NewGame.cs
  + PauseMenuu.cs
  + PlayerStats.cs
  + PutOnRaycast.cs
  + ViolinBieuDienRaycast.cs
  
- Trong folder Scripts (theo thứ tự alphabet):
  + SaveSystem.cs
  + WorldPositionButton.cs
  + ZoomInTriggerRaycast.cs
  
- Trong folder ExamineSystem:
  + ExamineItemController.cs
  + ExamineRaycast.cs
  + ExamineDisableManager.cs
  
- Trong folder Door Interaction:
  + BasicDoorRaycast.cs

Và những thứ trong folder ScriptableObjects

Các Raycast:
  + PutOnRaycast.cs
  + ViolinBieuDienRaycast.cs
  + ExamineRaycast.cs
  + BasicDoorRaycast.cs

Về InventorySystem có những thứ đáng lưu ý sau:
  + Để tạo Item mới, Bước 1: vào ScriptableObjects -> Items, nhấn chuột phải, Create -> Inventory System -> Items, chọn Others, Bước 2: Quay ra Assets -> Resources chọn Database.asset add
  thêm Item mình mới thêm. 
  * Lưu ý, nhớ đổi id cho đúng thứ tự, lẫn ở bước 1 và bước 2.
  + Bước 3: tạo object trong scene, gắn ExamineItemController và GroundItem vào, trong GroundItem tùy Item mà gắn vào mục Item. 

Cách hoạt động của việc lấy và sử dụng Item trong Inventory:
  + Người chơi sẽ qua ExamineRaycast chọn vật lấy được.
  + Vật lấy được sẽ có script GroundItem. 
  + Khi người chơi nhấp vào vật lấy được, ExamineRaycast sẽ biết được vật có Component GroundItem, từ đó AddItem vào Inventory.
  + Khi nhấp E, sẽ hiện lên màn hình Inventory. (InventoryDisappear.cs)
  + Nếu hover con chuột lên một Item, nó sẽ hiện cái Description của mỗi Item, khi nhấp vào, nếu đúng tình huống thì hành động sẽ được thực hiện, nếu không thì sẽ có dòng
  chữ nói rằng không thực hiện được gì. (DisplayInventory.cs)
  
Sẽ update tiếp cách hoạt động của SavingSystem.
