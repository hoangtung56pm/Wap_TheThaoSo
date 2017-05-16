<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameShow.aspx.cs" Inherits="Wap_TheThaoSo.Wap.GameShow" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>


<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />	

    <title>.: viSport - Cong Thong Tin The Thao Danh Cho Mang Vietnamobile :.</title>

    <link href="/CssHandler.ashx?t=WapCss&f=style.css&v=<%= AppEnv.GetSetting("CssVersion") %>" rel="stylesheet" type="text/css" media="screen" />
    
    <style>
    
    .btn-danger {
        background-color: #d9534f;
        border-color: #d43f3a;
        color: #fff;
        cursor: pointer;
    }

    </style>

</head>
<body>
    <form id="form1" runat="server">

    <uc1:header ID="Header1" runat="server" /> 
        
    <div style="padding-left:15px; padding-right:15px;">
        
        <p align="center" class="color-red bold">***** Cháy cùng Euro*****</p>
        
        <p style="display: none;" align="center">
            <asp:Button ID="btnBatDau" CssClass="btn-danger" Text="Bắt Đầu" runat="server" OnClick="btnBatDau_Click"/>
        </p>
        
        <div align="center">

       <%-- <p align="center">--%>
            
            <table align="center">
                
                <tr>
                    <td>SĐT</td>
                    <td>
                        <asp:TextBox runat="server" EnableViewState="False" ID="txtUserId"></asp:TextBox>
                        (vd:84123456789)
                    </td>
                </tr>
                
                <tr>
                    <td></td>
                    <td>
                        <asp:Button CssClass="btn-danger" runat="server" ID="btnTim" Text="Tra cứu" OnClick="btnTim_Click"/>
                    </td>
                </tr>

            </table>

            <asp:Repeater runat="server" ID="rptMdt" EnableViewState="False">
                
                <HeaderTemplate>
                     <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
                        <tr class="bold" align="center" style="color:Black;height:25px; background-color:#FF6600;">
                            <td width="10%">STT</td>
                            <td width="80%">Mã dự thưởng</td>
                        </tr>
                </HeaderTemplate>
                
                <ItemTemplate>
                        <tr align="center">
                            <td><%# Eval("RowNumber") %></td>
                            <td><%# Eval("Code") %></td>
                        </tr>
                </ItemTemplate>
                
                <FooterTemplate>
                     </table>
                </FooterTemplate>

            </asp:Repeater>

        <%--</p>--%>

        </div>

        <p class="color-red bold">I/ Giới thiệu chương trình khuyến mại </p>
        
        <p class="bold">1. Tên chương trình khuyến mại: “ Cháy cùng euro ”</p>
        <p class="bold">2. Thời gian khuyến mại: 9/6/2016 đến 11/07/2016</p>
        
        <p class="bold">3. Phạm vi khuyến mại:</p>
        <p>Toàn bộ thuê bao di động trả trước và trả sau mạng Vietnamobile trên lãnh thổ Việt Nam.</p>
        <p class="bold">4. Hình thức khuyến mại: </p>
        <p>
            Chương trình “Cháy Cùng Euro” cho phép khách hàng sử dụng miễn phí toàn bộ chức năng của dịch vụ Visport đồng thời nhận 5 câu hỏi miễn phí mỗi ngày để trả lời câu hỏi tích mã dự thưởng để tham gia quay thưởng với cơ hội trúng thưởng lên đến 30.000.000 đồng

        </p>
        
        <p class="bold">5. Cơ cấu giải thưởng: 1 giải nhất  20.000.000 và 2 giải nhì mỗi giải 5.000.000</p>
       
        
        
        <p class="color-red bold">II/ Cách thức tham gia </p>
        
        <p>
            - Để tham gia chương trình khuyến mại, khách hàng cần đăng ký dịch vụ như sau:<br />
            + Đăng ký tham gia chương trình qua SMS: Soạn EU gửi 979<br />
            + Đăng ký qua wap: link đăng ký<br />
            Sau khi đăng ký thành công, hệ thống sẽ gửi  SMS thông báo khách hàng đăng ký thành công
            <i>
               Chuc mung ban da tham gia CTKM Cháy Cùng Euro cua Vietnamobile. Ban co 5 ma du thuong de co co hoi trung thuong 30 trieu tien mat. Moi ngay ban se duoc tra loi cau hoi de  nang cao co hoi trung thuong (5000d/ngay). Truy cap: http://visport.vn de su dung dich vu. De huy dvu soan: HUY EU gui 979. HT: 19001255<br />

            </i>

            - Khách hàng sẽ được xem, tải toàn bộ các thông tin về những giải đấu hàng đầu trên thế giới, cập nhật tin tức, lịch thi đầu, kết quả, video liên tục 24/7 trên wapsite http://visport.vn<br /><br />
            - Ngoài ra, mỗi ngày khách hàng sẽ nhận được 5 câu hỏi với 2 đáp án lựa chọn. Khách hàng có thể trả lời qua SMS hoặc sử dụng 3g truy cập wapsite http://visport.vn vào phần Cháy Cùng Euro để trả lời câu hỏi<br /><br />
            - Câu hỏi đầu tiên sẽ được gửi về từ 00h đến 23h59:59 hàng ngày sau khách hàng được charge cước thành công<br /><br />
            - Thời gian câu trả lời được tính đến 23h59:59 cùng ngày<br /><br />
            - Giá cước dịch vụ: 5.000đ/ngày<br /><br />
            - Sau khi khách hàng trả lời hết 5 câu hỏi miễn phí trong ngày, ở câu hói thứ 5 sẽ thông báo cho khách hàng có muốn trả lời tiếp các câu hỏi không, các câu hỏi mua thêm sẽ được tính 1.000đ/câu hỏi. Không giới hạn số lượng câu hỏi trả lời thêm.<br /><br />
            - Câu hỏi mua thêm được trả về qua SMS<br /><br />
            - Khi đăng ký thành công; gia hạn thành công dịch vụ hoặc trả lời đúng các câu hỏi, khách hàng sẽ nhận được số mã dự thưởng tuơng ứng.<br /><br />
            - Để trả lời câu hỏi khách hàng soạn tin theo cú pháp A hoặc B gửi 979<br /><br />
            - Các khách hàng không đăng ký gói dịch vụ khi tải, xem, nghe các nội dung mất phí trên wapsite sẽ bị tính phí như bình thường.<br /><br />


         </p>

        
        
        
        
        <p class="bold">- <i>Điểm tích lũy của chương trình được quy định như sau:</i></p>

        <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr class="bold" align="left" style="color:Black;height:25px; background-color:#FF6600;">
                <td width="70%">Nội dung tương tác</td>
                <td width="30%">Mã dự thưởng</td>
                
            </tr>           
            <tr align="center">               
                <td>Thuê bao đăng ký sử dụng dịch vụ lần đầu tiên.</td>
                <td>5</td>
            </tr>
            <tr align="center">               
                <td>Thuê bao đăng ký lại trong thời gian đang được miễn phí.</td>
                <td>0</td>
            </tr>
            
            <tr align="center">                
                <td>Thuê bao thực hiện giao dịch đăng ký lại kể từ ngày thứ 02 trở đi.</td>
                <td>5</td>
            </tr>
            <tr align="center">                
                <td>Gia hạn thành công .</td>
                <td>5 (trừ được cước 5.000 đồng)</td>
            </tr>
             <tr align="center">                
                <td>Trả lời sai .</td>
                <td>0</td>
            </tr>
             <tr align="center">                
                <td>Trả lời đúng mỗi câu hỏi .</td>
                <td>1</td>
            </tr>

         </table>

        <p>
        - Mã dự thưởng là một dãy số gồm 10 số tự nhiên được hệ thống tự động sinh ra<br /><br />
        - Khách hàng xem MDT hiện có bằng cách truy cập vào wapsite  nhập số điện thoại để xem thông tin MDT của mình <br /><br />
        - Mã số dự thưởng chỉ có giá trị khi thuê bao vẫn đang active dịch vụ, trường hợp thuê bao đã hủy dịch vụ thì mã dự thưởng của thuê bao đó sẽ không đưa vào dữ liệu dùng để quay thưởng.<br /><br />
        - Mã dự thưởng được tính từ 00h ngày 09/06/2016 đến hết chương trình khuyến mại Cháy Cùng Euro.<br /><br />
        </p>
       
         <p class="color-red bold">III/ Cú pháp nhắn tin và giá cước </p>
        <p class="bold">- <i>Cú pháp nhắn tin :</i></p>
        <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr class="bold" align="left" style="color:Black;height:25px; background-color:#FF6600;">
                <td width="20%">STT</td>
                <td width="40%">Nội dung tương tác</td>
                <td width="40%">Cú pháp</td>
                
            </tr>
           
            <tr align="center">
               
                <td>1</td>
                <td>Đăng ký dịch vụ</td>
                <td>EU gửi 979</td>
            </tr>
            
            <tr align="center">
                
                <td>2</td>
                <td>Huỷ dịch vụ</td>
                <td>HUY EU gửi 979</td>
            </tr>
            <tr align="center">
                
                <td>3</td>
                <td>Lấy câu hỏi hàng ngày</td>
                <td>CH gửi 979</td>
            </tr>
            <tr align="center">
                
                <td>4</td>
                <td>Nhận hướng dẫn sử dụng dịch vụ</td>
                <td>HDAN gửi 979</td>
            </tr>
            <tr align="center">
                
                <td>5</td>
                <td>Truy vấn mã dự thưởng</td>
                <td>DT gửi 979</td>
            </tr>
            <tr align="center">
                
                <td>6</td>
                <td>Trả lời câu hỏi</td>
                <td>A hoặc B gửi 979</td>
            </tr>

         </table>
        
        <p class="bold">- <i>Cước phí tin nhắn trong chương trình: :</i></p>
        <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr class="bold" align="left" style="color:Black;height:25px; background-color:#FF6600;">
                <td width="20%">STT</td>
                <td width="40%">Nội dung tương tác</td>
                <td width="40%">Cú pháp</td>
                
            </tr>
           
            <tr align="center">
               
                <td>1</td>
                <td>SMS đến đầu số 979</td>
                <td>Miễn phí</td>
            </tr>
            
            <tr align="center">
                
                <td>2</td>
                <td>Cước thuê bao ngày dịch vụ</td>
                <td>5.000 đ/ngày( charge lùi từ 5.000đ,3.000đ, 2.000đ, 1.000đ)</td>
            </tr>  
             <tr align="center">
                
                <td>3</td>
                <td>Cước trả lời câu hỏi thêm</td>
                <td>1.000đ/câu hỏi</td>
            </tr>           

         </table><br />
        <p class="color-red bold">IV/ Nguyên tắc trừ cước</p>
        <p>
            - Miễn phí sử dụng dịch vụ trong 01 ngày đầu tiên cho tất cả các khách hàng đăng ký sử dụng dịch vụ lần. Từ ngày thứ 2 sẽ thực hiện tính cước thuê bao theo giá cước của dịch vụ (5.000đ/ngày)<br /><br />
            - Nếu khách hàng thực hiện hủy và đăng ký gói trong vòng 01 ngày kể từ lần đăng ký đầu tiên thì các lần đăng ký lại sẽ không bị trừ cước và không nhận được thêm mã dự thưởng tích lũy cho các lần đăng ký lại đó.<br /><br />
            - Cước thuê bao dịch vụ trừ vào tài khoản chính (đối với thuê bao trả trước) hoặc ghi vào hóa đơn cước hàng tháng (với thuê bao trả sau).<br /><br />
            - Tại thời điểm gia hạn gói cước, hệ thống sẽ thực hiện trừ cước thuê bao của dịch vụ:<br /><br />
            + Nếu trừ cước thành công: khách hàng sẽ tiếp tục sử dụng dịch vụ như bình thường.<br />
            + Nếu trừ cước không thành công: tạm dừng dịch vụ của khách hàng. Hệ thống sẽ triển khai thực hiện trừ cước lại trong 35 ngày tiếp theo. Nếu việc trừ cước thành công khách hàng tiếp tục được sử dụng dịch vụ, nếu việc trừ cước không thành công trong 35 ngày liên tiếp, sẽ tiến hành hủy dịch vụ của khách hàng.<br /><br />
            - Trường hợp thuê bao bị khoá 01 chiều, hệ thống sẽ tạm dừng cung cấp dịch vụ cho đến khi thuê bao hoạt động 02 chiều trở lại, vẫn được bảo lưu và cộng dồn mã dự thưởng tham gia quay thưởng.<i> (Trong thời gian thuê bao bị chặn 01 chiều, hệ thống sẽ không thực hiện trừ cước, không trả mã dự thưởng cho thuê bao đó. Sau khi thuê bao hoạt động 02 chiều trở lại, hệ thống sẽ mở lại dịch vụ và không trừ bù tiền của khách hàng trong thời gian bị khoá 01 chiều đó)</i>.<br /><br />
            - Trường hợp thuê bao bị khóa 2 chiều, hệ thống sẽ tự động hủy dịch vụ của khách hàng, đồng thời toàn bộ mã dự thưởng của thuê bao tích lũy trước đó sẽ không được bảo lưu. Khi đó, khách hàng muốn sử dụng gói phải tự đăng ký lại.<br /><br />



        </p>
        <p class="color-red bold">V/ Cách thức xác định thuê bao trúng thưởng</p>
        <p>
            - Việc quay thưởng được thực hiện theo hình thức quay số phần mềm điện tử tại: công ty cổ phần truyền thông VMG, tầng 7 tòa nhà Viễn Đông 36 Hoàng Cầu và được chứng kiến bởi đại diện của Công ty Cổ phần Truyền thông VMG<br /><br />
            - Việc quay thưởng sẽ được diễn ra sau khi kết thúc thời gian dự thưởng 10 ngày. Dữ liệu bao gồm tập các mã dự thưởng của các thuê bao đang active dịch vụ đến thời điểm quay thưởng. Hệ thống quay thưởng sẽ xác định ngẫu nhiên 01 mã số trúng thưởng tương ướng với 01 số thuê bao thông qua quay số bằng phần mềm điện tử.<br /><br />

        </p>
        <p class="color-red bold">VI/ Thời gian, thủ tục và địa điểm trao thưởng</p>
        <p>
            - Các thuê bao trúng thưởng được trả thưởng theo quy trình do Vietnamobile quy định. <br /><br />
- Giải thưởng của chương trình chỉ được trao cho chủ thuê bao trúng thưởng. Trường hợp chủ thuê bao không thể nhận giải có thể làm giấy ủy quyền có xác nhận của cấp có thẩm quyền (Phường, xã) cho người khác nhận thay.<br /><br />
- Trường hợp số thuê bao trúng thưởng là thuê bao trả sau: giải thưởng chỉ được trao cho chủ thuê bao đứng tên trên hợp đồng tại thời điểm thông báo trúng thưởng.<br /><br />
- Trường hợp số thuê bao trúng thưởng là thuê bao trả trước: giải thưởng được trao cho chủ thuê bao đang sử dụng số điện thoại đó tại thời điểm xác minh.<br /><br />
- Vào thời điểm nhận giải thưởng số thuê bao trúng thưởng phải đang ở trạng thái hoạt động cả 2 chiều.  <br /><br />
- Các thuê bao trúng thưởng phải có nghĩa vụ đóng các khoản thuế theo quy định của Nhà nước. Các thuê bao từ chối nộp thuế sẽ không nhận được giải thưởng. Thuế được nộp bằng tiền mặt và do Vietnamobile thu hộ, sau đó chuyển trả cơ quan thuế.
- Nếu sau 07 (bảy) ngày làm việc mà không có khiếu nại hoặc tranh chấp nào về số thuê bao trúng thưởng thì Công ty Vietnamobile sẽ tiến hành các thủ tục xác minh để xác định thuê nào trúng thưởng và tiến hành các thủ tục trao giải. Nếu có tranh chấp, quyết định của Vietnamobile sẽ là quyết định cuối cùng có hiệu lực.<br /><br />
- Các thuê bao trúng thưởng nếu không xác định được chủ nhân nhận thưởng hoặc thuê bao tham gia không hợp lệ hoặc thuê bao từ chối nhận thưởng thì giải thưởng sẽ được trao cho số thuê bao có điểm số cao tiếp theo ·       Công ty Vietnamobile sẽ tiến hành trả thưởng cho khách hàng trong vòng 30 (ba mươi) ngày kể từ ngày kết thúc chương trình khuyến mại.<br /><br />
- Chủ nhân của các thuê bao trúng thưởng sẽ phải tự chịu chi phí đi lại, ăn ở khi đến nhận thưởng.<br /><br />
- Địa điểm trả thưởng:<br /><br />
+   Đối với các khách hàng tại Hà Nội: khách hàng đến nhận giải tại Tầng 5 tòa nhà King, Số 7 Chùa Bộc – Đống Đa - Hà Nội.<br />
+   Đối với khách hàng tại tỉnh/thành phố khác: khách hàng đến nhận giải tại Tầng 5 tòa nhà King, Số 7 Chùa Bộc – Đống Đa - Hà Nội hoặc đại diện của Vietnamobile tại tỉnh/thành phố đó.<br />
+   Hoặc Vietnamobile có thể thực hiện chuyển giải thưởng của khách hàng thông qua tài khoản Ngân hàng của khách hàng hoặc sử dụng dịch vụ chuyền tiền qua Ngân hàng, người hưởng nhận bẳng Chứng minh thư nhân dân.<br />
+   Vietnamobile có quyền sử dụng tên, hình ảnh của các khách hàng trúng thưởng cho hoạt động truyền thông, quảng cáo… cho chương trình<br />
        </p>

        <p class="color-red bold">VII/ Thông báo thuê bao trúng thưởng: </p>
        <p>
            Thông tin người trúng thưởng sẽ được thông báo rộng rãi trên website vietnamobile.com.vn. Ngoài ra trung tâm thông tin di động Vietnamobile sẽ thực hiện nhắn tin và gọi điện thông báo cho các thuê bao trúng thưởng và thực hiện quá trình xác minh khách hàng trúng thưởng.<br />
        </p>
    </div>

    <%--<div style="padding-left:15px; padding-right:15px;">
        
        <p align="center" class="color-red bold">***** ANH TÀI BÓNG ĐÁ *****</p>

        <p class="color-red bold">Giới thiệu:</p>

        <p>“ Anh tài bóng đá  là chương trình nhắn tin trúng thưởng với nhiều nội dung hấp dẫn, thú vị của Vietnamobile. Khách hàng không chỉ có cơ hội giành nhiều phần thưởng giá trị mà còn được tham gia vào một sân chơi lý thú để thử tài và nâng cao kiến thức bóng đá với nhiều nội dung hỏi đáp hấp dẫn.”</p>

        <p class="bold">Soạn BD gửi 979 để tham gia ngay</p>

         <p class="color-red bold">Thông tin chương trình </p>

         <p class="bold">1. Tên chương trình: “ ANH TÀI BÓNG ĐÁ ”</p>

         <p class="bold">2. Thời gian chương trình:</p>
         <p>
            Từ 0h00 ngày 01/01/2014 đến 23h59:59 ngày 30/06/2014
         </p>

         <p class="bold">3. Hình thức khuyến mại:</p>
         <p>
            Trao thưởng cho thuê bao có điểm số cao nhất
         </p>

         <p class="bold">4. Đối tượng tham gia:</p>
         <p>
            Thuê bao (trả trước và trả sau) đang hoạt động hai chiều trên mạng Vietnamobile.
         </p>

         <p class="bold">5. Cơ cấu giải thưởng:</p>
         <p> Chương trình chia làm 3 đợt: </p>
         <p> Đợt 1: Từ ngày 01/01/2014 đến hết ngày 28/02/214 </p>
         <p> Đợt 2: Từ ngày 01/03/2014 đến hết ngày 30/04/2014 </p>
         <p>  Đợt 3: Từ ngày 01/05/2014 đến hết ngày 30/06/2014 </p>

         <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr class="bold" align="center" style="color:Black;height:25px; background-color:#FF6600;">
                <td width="10%">STT</td>
                <td width="20%">Cơ cấu giải thưởng</td>
                <td width="20%">Giá trị (VNĐ)</td>
                <td width="20%">Số lượng</td>
                <td width="20%">Thành tiền (VNĐ)</td>
            </tr>

            <tr align="center">
                <td>1</td>
                <td>
                   Giải tuần <br />
                   Thẻ cào trị giá 200.000
                </td>
                <td>200.000</td>
                <td>26</td>
                <td>5.200.000</td>
            </tr>

            <tr align="center">
                <td>2</td>
                <td>
                   Giải đợt <br />
                   IPAD MINI WIFI 16GB BLACK/WHITE
                </td>
                <td>10.000.000</td>
                <td>3</td>
                <td>30.000.000</td>
            </tr>

            <tr align="center">
                <td>3</td>
                <td>
                   Giải chung cuộc <br />
                   Phần quà bằng tiền mặt
                </td>
                <td>50.000.000</td>
                <td>1</td>
                <td>50.000.000</td>
            </tr>

            <tr align="center">
                <td>4</td>
                <td>
                   Tổng số giải thưởng
                </td>
                <td></td>
                <td>30</td>
                <td>85.300.000</td>
            </tr>

         </table>
        
          <p class="bold">6. Nội dung chương trình:</p>

          <p>Thuê bao trên mạng Vietnamobile sau khi đăng ký dịch vụ Visport sẽ được tham gia chương trình khuyến mại và trả lời câu hỏi để tích lũy điểm số và nâng cao cơ hội chiến thắng, cụ thể như sau:</p>

          <p>- Khách hàng đăng ký tham dự bằng cách soạn tin BD gửi đến đầu số 979</p>
          <p>  + Miễn phí đăng ký cho khách hàng lần đầu tiên đăng ký.</p>
          <p>  + Từ ngày thứ 2 phí duy trì dịch vụ là 5.000VNĐ/ngày</p>
          <p>- Sau khi đăng ký tham gia chương trình, hàng ngày khách hàng sẽ được trả lời miễn phí tối đa 6 câu hỏi theo nguyên tắc khách hàng nhắn tin trả lời lên hệ thống sẽ tự động kích hoạt gửi về câu hỏi tiếp theo. Số câu hỏi tối thiểu khách hàng nhận được là 1 câu hỏi nếu khách hàng không trả lời câu hỏi đầu tiên. Sau khi khách hàng trả lời hết số câu hỏi miễn phí trong ngày sẽ được mời trả lời thêm câu hỏi tính phí với mức cước 1000VNĐ/câu. </p>

          <p>Số câu hỏi tối đa khách hàng nhận được trong ngày là 15 câu hỏi ( bao gồm cả 6 câu hỏi miễn phí đầu tiên)</p>

          <p>- Khách hàng có cơ hội nhận được câu hỏi may mắn, trường hợp trả đúng khách hàng sẽ nhận được gấp đôi hoặc ba lần số điểm cho một câu trả lời đúng. Trường hợp khách hàng trả lời sai sẽ bị trừ đi 40 điểm.</p>

          <p>- Thời gian bắt đầu gửi về câu hỏi từ 8h00 đến 23h59 hàng ngày. Trường hợp khách hàng nhăn tin trả lời vào ngày hôm sau ( từ 0h00 đến 7h59 ), hệ thống sẽ chỉ trả thông báo điểm nhưng không trả thêm câu hỏi của ngày hôm trước.</p>

          <p>- Khách hàng hủy dịch vụ bằng cách soạn tin TC hoặc HUY BD gửi đến đầu số 979. Hệ thống sẽ dừng không gửi các câu hỏi hoặc câu mời khách hàng tham gia chương trình</p>

          <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr class="bold" align="center" style="color:Black;height:25px; background-color:#FF6600;">
                <td width="20%">Tuần</td>
                <td width="40%">Thời gian</td>
                <td width="40%">Số điện thoại</td>
            </tr>

            <tr align="center">
                <td>1</td>
                <td>01/01 đến ngày 07/01/2014</td>
                <td>841867100xxx</td>
            </tr>

            <tr align="center">
                <td>2</td>
                <td>08/01 đến ngày 14/01/2014</td>
                <td>84925742xxx</td>
            </tr>

            <tr align="center">
                <td>3</td>
                <td>15/01 đến ngày 21/01/2014</td>
                <td>84925866xxx</td>
            </tr>

            <tr align="center">
                <td>4</td>
                <td>22/01 đến ngày 28/01/2014</td>
                <td>84925866xxx</td>
            </tr>

             <tr align="center">
                <td>5</td>
                <td>29/01 đến ngày 04/02/2014</td>
                <td>841864925xxx</td>
            </tr>

              <tr align="center">
                <td>6</td>
                <td>05/02 đến ngày 11/02/2014</td>
                <td>84924051xxx</td>
            </tr>

              <tr align="center">
                <td>7</td>
                <td>12/02 đến ngày 18/02/2014</td>
                <td>84925869xxx</td>
            </tr>

              <tr align="center">
                <td>8</td>
                <td>19/02 đến ngày 25/02/2014</td>
                <td>841864967xxx</td>
            </tr>

              <tr align="center">
                <td>9</td>
                <td>26/02 đến ngày 04/03/2014</td>
                <td>84188502xxx</td>
            </tr>

              <tr align="center">
                <td>10</td>
                <td>05/03 đến ngày 11/03/2014</td>
                <td>84925693xxx</td>
            </tr>

              <tr align="center">
                <td>11</td>
                <td>12/03 đến ngày 18/03/2014</td>
                <td>841868245xxx</td>
            </tr>

              <tr align="center">
                <td>12</td>
                <td>19/03 đến ngày 25/03/2014</td>
                <td>84922012xxx</td>
            </tr>

              <tr align="center">
                <td>13</td>
                <td>26/03 đến ngày 01/04/2014</td>
                <td>841867810xxx</td>
            </tr>
              
              <tr align="center">
                <td>14</td>
                <td>2/04 đến ngày 08/04/2014</td>
                <td>84925693xxx</td>
            </tr>
              
               <tr align="center">
                <td>15</td>
                <td>9/04 đến ngày 15/04/2014</td>
                <td>841864925xxx</td>
                </tr>
                   
                <tr align="center">
                <td>16</td>
                <td>16/04 đến ngày 22/04/2014</td>
                <td>841867810xxx</td>
                    </tr>
                    
                 <tr align="center">
                <td>17</td>
                <td>23/04 đến ngày 29/04/2014</td>
                <td>84925866xxx</td>
                     </tr>
                     
                <tr align="center">
                <td>18</td>
                <td>30/04 đến ngày 06/05/2014</td>
                <td>841884872xxx</td> 
                    </tr>
              
              
                <tr align="center">
                <td>19</td>
                <td>7/05 đến ngày 13/05/2014</td>
                <td>84925693xxx</td> 
                    </tr>
              
              
               <tr align="center">
                <td>20</td>
                <td>14/05 đến ngày 20/05/2014</td>
                <td>841863912xxx</td> 
                </tr>
              
              <tr align="center">
                <td>21</td>
                <td>21/05 đến ngày 27/05/2014</td>
                <td>841864771xxx</td> 
                </tr>
              
              
              <tr align="center">
                <td>22</td>
                <td>28/05 đến ngày 3/06/2014</td>
                <td>841867911xxx</td> 
                </tr>
              
              <tr align="center">
                <td>23</td>
                <td>3/06 đến ngày 9/06/2014</td>
                <td>841869135xxx</td> 
                </tr>
              
              <tr align="center">
                <td>24</td>
                <td>10/06 đến ngày 16/06</td>
                <td>841884872xxx</td> 
              </tr>
              
              <tr align="center">
                <td>25</td>
                <td>17/06 đến ngày 23/06</td>
                <td>841867911xxx</td> 
              </tr>
              
              <tr align="center">
                <td>26</td>
                <td>24/06 đến ngày 30/06</td>
                <td>841865321xxx</td> 
              </tr>

          </table>

          <br />

           <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr class="bold" align="center" style="color:Black;height:25px; background-color:#FF6600;">
                <td width="20%">Đợt</td>
                <td width="40%">Thời gian</td>
                <td width="40%">Số điện thoại</td>
            </tr>

            <tr align="center">
                <td>1</td>
                <td>01/01 đến ngày 28/02/2014</td>
                <td>841864925xxx</td>
            </tr>
               
               <tr align="center">
                <td>2</td>
                <td>01/03 đến ngày 30/04/2014</td>
                <td>841884872xxx</td>
            </tr>
               
                <tr align="center">
                <td>3</td>
                <td>01/05 đến ngày 30/06</td>
                <td>841865321xxx</td>
            </tr>


          </table>
        
        <br />
        
        <table style="border-color:#FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr class="bold" align="center" style="color:Black;height:25px; background-color:#FF6600;">
                <td width="20%">Đợt</td>
                <td width="40%">Thời gian</td>
                <td width="40%">Số điện thoại</td>
            </tr>

            <tr align="center">
                <td>Chung cuộc</td>
                <td>01/01 - 30/06 </td>
                <td>841884872xxx</td>
            </tr>


          </table>

          <p><a href="<%= AppEnv.GetSetting("WapDefault") %>"><< Quay về Trang chủ</a></p>

    </div>--%>

    </form>
</body>
</html>
