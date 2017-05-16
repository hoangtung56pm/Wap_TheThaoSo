<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CTKMGV.aspx.cs" Inherits="Wap_TheThaoSo.CTKMGV" %>

<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">

    <uc1:header ID="Header1" runat="server" /> 
        
    <div style="padding-left:15px; padding-right:15px;">
        
        <p align="center" class="color-red bold">CHƯƠNG TRÌNH KHUYẾN MÃI DỊCH VỤ VISPORT/GAME PORTAL TRÊN MẠNG VIETNAMOBILE</p>
        
       

        <p class="color-red bold">Thông tin chương trình </p>
        
        <p class="bold"><b>1.	Thời gian triển khai: 0h 18/03/2016 đến 23h59:59 ngày 18/06/2016</b></p>
        
        <p class="bold"><b>2.	Đối tượng tham gia: Thuê bao (trả trước và trả sau) đang hoạt động hai chiều trên mạng Vietnamobile.</b></p>        
        
        <p class="bold"><b>3.	Giải thưởng: </b></p>
        <p>
            Một Iphone 6s 16G trị giá 17.000.000 VND, màu sắc do Công ty cổ phần truyền thông VMG quy định.
         </p>        
        
        <p class="bold"><b>4.	Hình thức khuyến mại: trao thưởng cho thuê bao có điểm số cao nhất</b></p>

        <p class="bold"><b>5.	Dịch vụ thực hiện chương trình khuyến mại: Visport và Game Portal</b></p>
                
        <p class="bold"><b>6.	Nội dung chương trình:</b></p>

        <p>
           -	KH đăng ký tham gia chương trình tích lũy điểm bằng cách đăng ký dịch vụ, gia hạn dịch vụ và mua lẻ game<br />
-	Trường hợp khách hàng hủy dịch vụ trong thời gian diễn ra chương trình khuyến mại, toàn bộ số điểm của quý khách sẽ được bảo lưu.<br />
-	Khách hàng tham gia xét thưởng phải duy trì dịch vụ đến trước thời điểm 12h59:59 ngày 2/3/2016. <br />
-	Hệ thống không giới hạn điểm số mà khách hàng đạt được.<br />


        </p>

        <p class="bold"><b>7.	Cách thức tham gia chương trình:</b></p>
        <p>
          -   Dịch vụ Visport:<br />
            + Đăng ký qua SMS: soạn DK KM gửi 979<br />
            + Đăng ký qua link: <a href="http://visport.vn/Sub/DK.aspx">http://visport.vn/Sub/DK.aspx</a><br />
            Sau khi đăng ký thành công, hệ thống sẽ gửi  SMS thông báo khách hàng đăng ký thành công<br />
            <i>“Ban da dang ky thanh cong CT iPhone 6s trao tay TRI AN khach hang Vietnamobile cua dv Visport . KH co so diem cao nhat se so huu iPhone 6s vao cuoi CT. Duy tri dich vu de nhan diem hang ngay. Truy cap bang 3g vao trang <a href="http://visport.vn">http://visport.vn</a> de su dung dvu (5000d/ngay). De biet ro hon ve chuong trinh soan HD gui 2288. De huy dich vu soan HUY KM gui 979”</i><br />
            + KH sau khi đăng ký dịch vụ sẽ được nghe, xem, tải miễn phí toàn bộ nội dung trên wap http://visport.vn <br /><br />

            -   Dịch vụ Game Portal:<br />
            + Đăng ký qua SMS: soạn DK KM gửi 2288<br />
            + Đăng ký qua link: <a href="http://vmgame.vn/home/RegisGP">http://vmgame.vn/home/RegisGP</a><br />
                  + Sau khi đăng ký thành công, hệ thống sẽ gửi  SMS thông báo khách hàng đăng ký thành công <br />
            <i>“Ban da dang ky thanh cong CT iPhone 6s trao tay TRI AN khach hang Vietnamobile cua dv Game Portal. KH co so diem cao nhat se so huu iPhone 6s vao cuoi CT. Duy tri dich vu hoac mua game de tang co hoi so huu giai thuong. Truy cap bang 3g vao trang <a href="http://vmgame.vn">http://vmgame.vn</a> de su dung dvu (10000d/tuan). De biet ro hon ve chuong trinh soan HD gui 2288. De huy dich vu soan HUY KM gui 2288”</i><br />
            + Sau khi đăng ký thành công, KH được tặng 2 game mỗi tuần miễn phí.<br />
            -	Để biết số điểm đang có soạn tin TOP gửi 2288 (2000d/tin), hệ thống sẽ trả về MT với nội dung:<br />
            <i>“Quy khach co [xxxx] diem va dang xep thu [số thứ tự] de tham du tich diem trung iPhone 6s sanh dieu tu dich vu Visport/Game Portal cung Vietnamobile. CT se ket thuc vao ngay 2/3/2016. De tim hieu chuong trinh KM, Quy Khach vui long soan tin HD gui 2288. Chi tiet truy cap wapsite: <a href="http://visport.vn/Wap/CTKMGV.aspx">http://visport.vn/Wap/CTKMGV.aspx</a></i>

        </p>

        <p class="bold"><b>8.	Quy định điểm số</b></p>

        <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr class="bold" align="center" style="color:Black;height:25px; background-color:#FF6600;">
                <td width="10%">STT</td>
                <td width="20%">Nội dung</td>
                <td width="20%">Ghi chú</td>
                <td width="20%">Số điểm khách hàng nhận được </td>
            </tr>  

            <tr align="center">
                <td>1</td>
                <td>
                   <b>Đăng ký thành công dịch vụ Visport</b>
                </td>
                <td>Miễn phí</td>
                <td>0</td>                
            </tr>
            
            <tr align="center">
                <td>2</td>
                <td>
                   <b>Gia hạn thành công dịch vụ Visport </b>
                </td>
                <td>Đối với mỗi mức cước gia hạn được sẽ tặng số lượng điểm khác nhau nhau (quy ước: 1.000đ = 1.000 điểm)</td>
                <td>Đối với mỗi mức cước gia hạn được sẽ tặng số lượng điểm khác nhau nhau (quy ước: 1.000đ = 1.000 điểm)</td>                
            </tr>
            <tr align="center">
                <td>3</td>
                <td>
                   <b>Đăng ký thành công dịch vụ Game Portal </b>
                </td>
                <td>Miễn phí</td>
                <td>0</td>                
            </tr>
            <tr align="center">
                <td>4</td>
                <td>
                   <b>Gia hạn thành công dịch vụ Game Portal</b>
                </td>
                <td>Đối với mỗi mức cước gia hạn được sẽ tặng số lượng điểm khác nhau nhau (quy ước: 1.000đ = 1.000 điểm)</td>
                <td>Đối với mỗi mức cước gia hạn được sẽ tặng số lượng điểm khác nhau nhau (quy ước: 1.000đ = 1.000 điểm)</td>                
            </tr>
            <tr align="center">
                <td>5</td>
                <td>
                   <b>Mua lẻ game dịch vụ Game Portal  </b>
                </td>
                <td>Đối với từng game với mức cước khác nhau sẽ tặng số lượng điểm khác nhau (quy ước: 1.000đ = 1.000 điểm)</td>
                <td>Đối với từng game với mức cước khác nhau sẽ tặng số lượng điểm khác nhau (quy ước: 1.000đ = 1.000 điểm)</td>                
            </tr>
         </table>
      
        <p class="bold"><b>9.	Thời gian, thủ tục và địa điểm trao thưởng</b></p>
        <p>
            - Các thuê bao trúng thưởng được trả thưởng theo quy trình do công ty cổ phần truyền thông VMG phối hợp cùng Vietnamobile quy định. <br />
- Khách hàng trúng thưởng phải đảm bảo điều kiện duy trì dịch vụ đến 12h59:59 ngày 2/3/2016. <br />
- Giải thưởng của chương trình chỉ được trao cho chủ thuê bao trúng thưởng. Trường hợp chủ thuê bao không thể nhận giải có thể làm giấy ủy quyền có xác nhận của cấp có thẩm quyền (Phường, xã) cho người khác nhận thay.<br />
- Trường hợp số thuê bao trúng thưởng là thuê bao trả sau: giải thưởng chỉ được trao cho chủ thuê bao đứng tên trên hợp đồng tại thời điểm thông báo trúng thưởng.<br />
- Trường hợp số thuê bao trúng thưởng là thuê bao trả trước: giải thưởng được trao cho chủ thuê bao đang sử dụng số điện thoại đó tại thời điểm xác minh.<br />
- Vào thời điểm nhận giải thưởng số thuê bao trúng thưởng phải đang ở trạng thái hoạt động cả 2 chiều.  <br />
- Thời điểm 23h59:59 ngày 2/3/2016, thuê bao có số điểm tích lũy cao nhất là thuê bao trúng thưởng, trường hợp có nhiều thuê bao bằng điểm nhau thì thuê bao nào đạt đến số điểm cao nhất sớm nhất là thuê bao trúng thưởng.<br />
-  Các thuê bao trúng thưởng phải có nghĩa vụ đóng các khoản thuế theo quy định của Nhà nước. Các thuê bao từ chối nộp thuế sẽ không nhận được giải thưởng. Thuế được nộp bằng tiền mặt và do công ty cổ phần truyền thông VMG thu hộ, sau đó chuyển trả cơ quan thuế.<br />
-  Sau 03 (ba) ngày làm việc liên tiếp, nếu bộ phận chăm sóc khách của công ty cổ phần truyền thông VMG không liên hệ được với người trúng giải, giải thưởng sẽ được trao cho người có số điểm cao tiếp theo.<br />
- Nếu sau 07 (bảy) ngày làm việc mà không có khiếu nại hoặc tranh chấp nào về số thuê bao trúng thưởng thì công ty cổ phần truyền thông VMG sẽ tiến hành các thủ tục xác minh để xác định thuê bao nào trúng thưởng và tiến hành các thủ tục trao giải. Nếu có tranh chấp, quyết định của công ty cổ phần truyền thông VMG sẽ là quyết định cuối cùng có hiệu lực.<br />
- Các thuê bao trúng thưởng nếu không xác định được chủ nhân nhận thưởng hoặc thuê bao tham gia không hợp lệ hoặc thuê bao từ chối nhận thưởng thì giải thưởng sẽ được trao cho số thuê bao có điểm số cao tiếp theo <br />      
- Công ty cố phần truyền thông VMG sẽ tiến hành trả thưởng cho khách hàng trong vòng 30 (ba mươi) ngày kể từ ngày kết thúc chương trình khuyến mại.<br />
- Chủ nhân của các thuê bao trúng thưởng sẽ phải tự chịu chi phí đi lại, ăn ở khi đến nhận thưởng.<br />
- Địa điểm trả thưởng:
o    Đối với các khách hàng tại Hà Nội: khách hàng đến nhận giải tại Tầng 7 tòa nhà Viễn Đông, số 36 Hoàng Cầu, Đống Đa, Hà Nội<br />
o    Đối với khách hàng tại tỉnh/thành phố khác: công ty cổ phần truyền thông VMG có thể thực hiện chuyển giải thưởng của khách hàng thông qua dịch vụ chuyển phát nhanh Viettel Post khi đã xác minh được chính xác thông tin người trúng giải.<br />
o  Công ty cổ phần truyền thông VMG có quyền sử dụng tên, hình ảnh của các khách hàng trúng thưởng cho hoạt động truyền thông, quảng cáo… cho chương trình.<br />

         </p>
        
        <p class="bold"><b>10. Thông báo thuê bao trúng thưởng: </b></p>
        <p>
            
           Thông tin người trúng thưởng sẽ được thông báo rộng rãi trên website http://visport.vn/ và http://vmgame.vn/ . Ngoài ra Công ty cổ phần truyền thông VMG sẽ thực hiện nhắn tin và gọi điện thông báo cho các thuê bao trúng thưởng và thực hiện quá trình xác minh khách hàng trúng thưởng.<br />

        </p>
       

    </div>

   
    </form>
</body>
</html>
