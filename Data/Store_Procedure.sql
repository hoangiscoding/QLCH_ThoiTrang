--Tạo mới khách hàng
CREATE PROCEDURE CreateNewCustomer
	@Id varchar(50),
	@Username varchar(50),
	@Password varchar(100),
	@FullName nvarchar(50),
	@Gender nvarchar(4),
	@BirthDate datetime,
	@PhoneNumber varchar(10),
	@Email varchar(100),
	@Address nvarchar(200),
	@AvatarPath nvarchar(MAX),
	@Revenue int,
	@Rank nvarchar(50)
AS
BEGIN
    INSERT Customer (Id,Username,Password,FullName,Gender,BirthDate,PhoneNumber,Email,Address,AvatarPath, Revenue, Rank)
	VALUES (@Id,@Username,@Password, @FullName,@Gender,@BirthDate,@PhoneNumber,@Email,@Address,@AvatarPath,@Revenue,@Rank)
END;

--Tạo mới nhân viên
CREATE PROCEDURE CreateNewStaff
	@Id varchar(50),
	@Username varchar(50),
	@Password varchar(100),
	@FullName nvarchar(50),
	@Gender nvarchar(4),
	@BirthDate datetime,
	@PhoneNumber varchar(10),
	@Email varchar(100),
	@Address nvarchar(200),
	@AvatarPath nvarchar(MAX),
	@Role nvarchar(50)
AS
BEGIN
    INSERT Staff (Id,Username,Password,FullName,Gender,BirthDate,PhoneNumber,Email,Address,AvatarPath, Role)
	VALUES (@Id,@Username,@Password, @FullName,@Gender,@BirthDate,@PhoneNumber,@Email,@Address,@AvatarPath,@Role)
END;

--Tạo mới sản phẩm
CREATE PROC CreateNewProduct
	@Id varchar(50),
	@Name nvarchar(100),
	@Price int,
	@Type nvarchar(50),
	@Quantity int,
	@Size nvarchar(10),
	@Info nvarchar(MAX),
	@AvatarPath nvarchar(MAX)
AS
BEGIN
	INSERT Product(Id,Name,Price,Type,Quantity,Size,Info,AvatarPath)
	VALUES(@Id,@Name,@Price,@Type,@Quantity,@Size,@Info,@AvatarPath)
END;

--Tạo mới nhập hàng
CREATE PROC CreateNewImportGood
	@Id varchar(50),
	@StaffId varchar(50),
	@ProductId varchar(50),
	@ImportTime datetime,
	@Quantity int
AS
BEGIN
	INSERT ImportGood(Id,StaffId,ProductId,ImportTime,Quantity)
	VALUES(@Id,@StaffId,@ProductId,@ImportTime,@Quantity)
	
	--sửa thông tin về số lượng sản phẩm 
	UPDATE 
		Product
	SET 
		Quantity = Quantity + @Quantity
	WHERE Id = @ProductId
END;

--Tạo mới bill
CREATE PROC CreateNewBill
	@Id varchar(50),
	@StaffId varchar(50),
	@CustomerId varchar(50),
	@CreationTime datetime,
	@DiscountAmount float,
	@OriginalPrice float,
	@DiscountedTotal float
AS
BEGIN
	INSERT Bill(Id,StaffId,CustomerId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal)
	VALUES(@Id,@StaffId,@CustomerId,@CreationTime,@DiscountAmount,@OriginalPrice,@DiscountedTotal)
END;

--Tạo mới BillDetail
CREATE PROC CreateNewBillDetail
	@Id varchar(50),
	@ProductId varchar(50),
	@Quantity int,
	@Total float
AS
BEGIN
	INSERT BillDetail(Id,ProductId,Quantity,Total)
	VALUES(@Id,@ProductId,@Quantity,@Total)
END;

DROP PROC CreateNewBillDetail
--Thanh toán bill
CREATE PROC PayBill
	@Id varchar(50),
	@OriginalPrice float,
	@DiscountAmount float,
	@DiscountedTotal float
AS
BEGIN
	--Update Bill
	UPDATE Bill
	SET
		OriginalPrice = @OriginalPrice,
		DiscountAmount = @DiscountAmount,
		DiscountedTotal = @DiscountedTotal 
	WHERE 
		Id = @Id
END;

DROP PROC PayBill
--Update revenue cho khách hàng
CREATE PROC UpdatePaymentCustomer
	@DiscountedTotal float,
	@Id varchar(50)
AS 
BEGIN
	UPDATE Customer
	SET
		Customer.Revenue = Customer.Revenue + @DiscountedTotal,
		Customer.Rank = CASE
                    WHEN Revenue < 5000000 THEN N'ĐỒNG'
                    WHEN Revenue < 10000000 AND Revenue > 5000000 THEN N'BẠC'
					WHEN Revenue < 20000000 AND Revenue > 10000000 THEN N'VÀNG'
					ELSE N'KIM CƯƠNG'
               END
	WHERE Customer.Id = @Id
END;

--Update số lượng sản phẩm sau khi thêm vào giỏ hàng
CREATE PROC UpdateProduct
	@Id varchar(50),
	@Quantity int
AS
BEGIN
	UPDATE Product
	SET
	Quantity = @Quantity
	WHERE
	Id = @Id
END;

--Kiểm tra login của nhân viên và quản lý
CREATE PROCEDURE CheckLogin
	@Username varchar(50),
	@Password varchar(100),
	@Role nvarchar(50)
AS
BEGIN
    SELECT 
		Username,
		Password
		Role
	FROM 
		Staff
	WHERE
		Username = @Username
		AND
		Password = @Password
		AND 
		Role = @Role
END;

--Đọc các thông tin về username
CREATE PROCEDURE LoadUsername
AS
BEGIN
	SELECT 
		Username
	FROM 
		Staff
	UNION
	SELECT 
		Username
	FROM 
		Customer
END;

--Đọc các thông tin về email
CREATE PROCEDURE LoadEmail
AS
BEGIN
	SELECT 
		Email
	FROM 
		Staff
	UNION
	SELECT 
		Email
	FROM 
		Customer
END;

--Đọc các thông tin về SĐT
CREATE PROCEDURE LoadPhone
AS
BEGIN
	SELECT 
		PhoneNumber
	FROM 
		Staff
	UNION
	SELECT 
		PhoneNumber
	FROM 
		Customer
END;

--Đọc các thông tin về Customer
CREATE PROC LoadCustomer
AS
BEGIN
	SELECT 
		Id,
		Username,
		Password,
		FullName,
		Gender,
		BirthDate,
		PhoneNumber,
		Email,
		Address,
		AvatarPath,
		Revenue,
		Rank
	FROM 
		Customer
END


--Đọc các thông tin về Staff
CREATE PROC LoadStaff
AS
BEGIN
	SELECT 
		Id,
		Username,
		Password,
		FullName,
		Gender,
		BirthDate,
		PhoneNumber,
		Email,
		Address,
		AvatarPath,
		Role
	FROM 
		Staff
END

--Đọc các thông tin về sản phẩm
CREATE PROC LoadProduct
AS
BEGIN
	SELECT
		Id, Name,Price,Type,Quantity,Size,Info,AvatarPath
	FROM Product
END;

--Đọc các thông tin về nhập hàng
CREATE PROC LoadImportGood
AS
BEGIN
	SELECT 
		Id, StaffId, ProductId,ImportTime,Quantity
	FROM
		ImportGood
END;

--ĐỌc các thông tin về đơn hàng
CREATE PROC LoadBill
AS
BEGIN
	SELECT 
		Id, CustomerId,StaffId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal
	FROM 
		Bill
END;

--ĐỌc các thông tin về chi tiết đơn hàng
CREATE PROC LoadBillDetail
AS
BEGIN
	SELECT 
		Id, ProductId,Quantity,Total
	FROM 
		BillDetail
END;

--Sửa thông tin cá nhân của Nhân viên
CREATE PROC EditStaffInfo
	@Id varchar(50),
	@FullName nvarchar(50),
	@Gender nvarchar(4),
	@BirthDate datetime,
	@PhoneNumber varchar(10),
	@Email varchar(100),
	@Address nvarchar(200),
	@AvatarPath nvarchar(MAX),
	@Role nvarchar(50)
AS
BEGIN
UPDATE Staff
	SET
		FullName = @FullName,
		Gender = @Gender,
		BirthDate = @BirthDate,
		PhoneNumber = @PhoneNumber,
		Email = @Email,
		Address = @Address,
		AvatarPath = @AvatarPath,
		Role = @Role
	WHERE 
		Id = @Id
END

--Sửa thông tin cá nhân của Khách hàng
CREATE PROC EditCustomerInfo
	@Id varchar(50),
	@FullName nvarchar(50),
	@Gender nvarchar(4),
	@BirthDate datetime,
	@PhoneNumber varchar(10),
	@Email varchar(100),
	@Address nvarchar(200),
	@AvatarPath nvarchar(MAX),
	@Revenue int,
	@Rank nvarchar(50)
AS
BEGIN
UPDATE Customer
	SET
		FullName = @FullName,
		Gender = @Gender,
		BirthDate = @BirthDate,
		PhoneNumber = @PhoneNumber,
		Email = @Email,
		Address = @Address,
		AvatarPath = @AvatarPath,
		Revenue = @Revenue,
		Rank = @Rank
	WHERE 
		Id = @Id
END

--Sửa thông tin sản phẩm
CREATE PROC EditProductInfo
	@Id varchar(50),
	@Name nvarchar(100),
	@Price int,
	@Type nvarchar(50),
	@Quantity int,
	@Size nvarchar(10),
	@Info nvarchar(MAX),
	@AvatarPath nvarchar(MAX)
AS
BEGIN
	UPDATE Product
	SET
		Name = @Name,
		Price = @Price,
		Type = @Type,
		Quantity = @Quantity,
		Size = @Size,
		Info = @Info,
		AvatarPath = @AvatarPath
	WHERE
		Id = @Id
END;

--Sửa thông tin nhập hàng
CREATE PROC EditImportGoodInfo
	@Id varchar(50),
	@StaffId varchar(50),
	@ProductId varchar(50),
	@ImportTime datetime,
	@Quantity int
AS
BEGIN
	Update ImportGood
	SET 
		StaffId = @StaffId,
		ProductId = @ProductId,
		Quantity = @Quantity,
		ImportTime = @ImportTime
	WHERE Id = @Id
END;

--Sửa/Update Bill
CREATE PROC UpdateBill
	@Id varchar(50),
	@OriginalPrice float,
	@DiscountAmount float,
	@DiscountedTotal float
AS
BEGIN
	UPDATE Bill
	SET
		OriginalPrice = @OriginalPrice,
		DiscountAmount = @DiscountAmount,
		DiscountedTotal = @DiscountedTotal 
	WHERE 
		Id = @Id
END;

--Sửa/Update BillDetail
CREATE PROCEDURE UpdateBillDetail
    @Id VARCHAR(50),
    @ProductId VARCHAR(50),
    @Quantity INT,
    @Total FLOAT
AS
BEGIN
    UPDATE BillDetail
    SET Quantity = @Quantity,
        Total = @Total
    WHERE Id = @Id AND ProductId = @ProductId
END


--Xoá nhân viên khỏi danh sách thông qua username
CREATE PROC RemoveStaffByUsername
	@Username varchar(50)
AS
BEGIN
	DELETE FROM Staff
	WHERE Username = @Username
END

--Xoá sản phẩm khỏi danh sách
CREATE PROC RemoveProduct
	@Id varchar(50)
AS
BEGIN
	DELETE FROM Product
	WHERE Id = @Id
END

--Xoá phiếu nhập hàng khỏi danh sách thông qua id
CREATE PROC RemoveImportGood
	@Id varchar(50),
	@ProductId varchar(50),
	@Quantity varchar(50)
AS
BEGIN
	DELETE FROM ImportGood
	WHERE Id = @Id
	UPDATE Product
	SET 
		Product.Quantity -= @Quantity
END

--Đổi mật khẩu của nhân viên
CREATE PROC EditStaffPassword
	@Username varchar(50),
	@Password varchar(100)
AS
BEGIN
	UPDATE Staff
	SET
		Password = @Password
	WHERE 
		Username = @Username
END

--Tìm theo tên
CREATE PROC FindByName
	@Fullname nvarchar(50),
	@Table varchar(50)
AS
BEGIN
	IF @Table = 'Staff'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
		FROM 
			Staff
		WHERE
			Fullname LIKE N'%' + @Fullname + '%'
	END
	ELSE IF @Table = 'Customer'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath,Revenue,Rank
		FROM 
			Customer
		WHERE
			Fullname LIKE N'%' + @Fullname + '%'
	END
END

--Tìm theo Mã KH
CREATE PROCEDURE FindById
    @Id NVARCHAR(50),
    @Table VARCHAR(50)
AS
BEGIN
    IF @Table = 'Staff'
    BEGIN
        SELECT
            Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
        FROM 
            Staff
        WHERE
            Id LIKE @Id + '%'
    END
    ELSE IF @Table = 'Customer'
    BEGIN
        SELECT
            Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Revenue, Rank
        FROM 
            Customer
        WHERE
            Id LIKE @Id + '%'
    END
END




--Tìm theo SĐT
CREATE PROCEDURE FindByPhoneNumber
    @PhoneNumber NVARCHAR(50),
    @Table VARCHAR(50)
AS
BEGIN
    IF @Table = 'Staff'
    BEGIN
        SELECT
            Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
        FROM 
            Staff
        WHERE
            PhoneNumber LIKE @PhoneNumber + '%'
    END
    ELSE IF @Table = 'Customer'
    BEGIN
        SELECT
            Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Revenue, Rank
        FROM 
            Customer
        WHERE
            PhoneNumber LIKE @PhoneNumber + '%'
    END
END

--Tìm theo username
CREATE PROC FindByUsername
	@Username varchar(50),
	@Table varchar(50)
AS
BEGIN
	IF @Table = 'Staff'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
		FROM 
			Staff
		WHERE
			Username LIKE N'%' + @Username + '%'
	END
	ELSE IF @Table = 'Customer'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, NULL AS Revenue, NULL AS Rank
		FROM 
			Customer
		WHERE
			Username LIKE N'%' + @Username + '%'
	END
END

--Tìm theo năm sinh
CREATE PROC FindByBirthDate
	@BirthDate int,
	@Table varchar(50)
AS
BEGIN
	IF @Table = 'Staff'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
		FROM 
			Staff
		WHERE
			year(BirthDate) = @BirthDate
	END
END
GO

--Tìm theo giới tính
CREATE PROC FindByGender
	@Gender nvarchar(50),
	@Table varchar(50)
AS
BEGIN
	IF @Table = 'Staff'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
		FROM 
			Staff
		WHERE
			Gender = @Gender
	END
END
GO

--Tìm theo chức vụ
CREATE PROC FindByRole
	@Role nvarchar(50),
	@Table varchar(50)
AS
BEGIN
	IF @Table = 'Staff'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
		FROM 
			Staff
		WHERE
			Role = @Role
	END
END

--Tìm sản phẩm theo mã
CREATE PROC FindProductById
	@Id varchar(50)
AS
BEGIN
	SELECT
		Id, Name,Price, Type,Quantity,Size,Info,AvatarPath
	FROM 
		Product
	WHERE Id LIKE '%' + @Id + '%'
END;

--Tìm sản phẩm theo tên
CREATE PROC FindProductByName
	@Name varchar(50)
AS
BEGIN
	SELECT
		Id, Name,Price, Type,Quantity,Size,Info,AvatarPath
	FROM 
		Product
	WHERE Name LIKE '%' + @Name + '%'
END;

--Tìm nhập hàng theo mã đơn
CREATE PROC FindImportGoodById
	@Id varchar(50)
AS 
BEGIN
	SELECT 
		Id, StaffId,ProductId,ImportTime,Quantity
	FROM 
		ImportGood
	WHERE Id LIKE '%' + @Id + '%'
END;

--Tìm nhập hàng theo Tên NV
CREATE PROC FindImportGoodByStaffName
	@Name nvarchar(50)
AS 
BEGIN
	SELECT 
		Id, StaffId,ProductId,ImportTime,Quantity
	FROM 
		ImportGood
	WHERE 
		StaffId 
		IN 
		(
		SELECT Id
		FROM Staff
		WHERE Staff.FullName LIKE '%' + @Name + '%'
		)
END;

--Tìm nhập hàng theo ngày nhập
CREATE PROC FindImportGoodByDate
	@Date varchar(50)
AS 
BEGIN
	SELECT 
		Id, StaffId,ProductId,ImportTime,Quantity
	FROM 
		ImportGood
	WHERE DAY(ImportTime) = @Date
END;

--Tìm đơn hàng theo mã đơn
CREATE PROC FindBillById
	@Id varchar(50)
AS 
BEGIN
	SELECT 
		Id, CustomerId,StaffId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal
	FROM 
		Bill
	WHERE Id LIKE '%' + @Id + '%'
END;

--Tìm đơn hàng theo tên KH
CREATE PROC FindBillByCustomerName
    @Name nvarchar(50)
AS 
BEGIN
    SELECT 
        B.Id, B.CustomerId, B.StaffId, B.CreationTime, 
        B.DiscountAmount, B.OriginalPrice, B.DiscountedTotal
    FROM 
        Bill B
    INNER JOIN 
        Customer C ON B.CustomerId = C.Id
    WHERE 
        C.FullName LIKE '%' + @Name + '%'
END;


-- Tìm đơn hàng theo ngày nhập
CREATE PROC FindBillByDate
	@Date varchar(50)
AS 
BEGIN
	SELECT 
		Id, CustomerId,StaffId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal
	FROM 
		Bill
	WHERE DAY(CreationTime) = @Date
END;

--Xóa đơn hàng
CREATE PROCEDURE RemoveBill
    @Id NVARCHAR(50)
AS
BEGIN
    DELETE FROM BillDetail WHERE Id = @Id;
    DELETE FROM Bill WHERE Id = @Id;
END

--Xóa chi tiết đơn hàng
CREATE PROCEDURE RemoveBillDetail
	@Id VARCHAR(50),
    @ProductId VARCHAR(50)
AS
BEGIN
    DELETE FROM BillDetail WHERE Id = @Id AND ProductId = @ProductId;
END
