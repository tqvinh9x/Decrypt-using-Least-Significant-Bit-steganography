﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DecryptUsingLSB
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Bitmap bmpResize;
        const string END_MARK = "vinhy9x";
        public Form1()
        {
            InitializeComponent();
            Bitmap bmp = Base64StringToBitmap("/9j/4AAQSkZJRgABAQEAYABgAAD/4QEFRXhpZgAATU0AKgAAAAgACwEAAAMAAAABAMgAAAEBAAMAAAABAMgAAAECAAMAAAADAAAAkgEGAAMAAAABAAIAAAEVAAMAAAABAAMAAAEaAAUAAAABAAAAmAEbAAUAAAABAAAAoAEoAAMAAAABAAIAAAExAAIAAAALAAAAqAEyAAIAAAAUAAAAs4dpAAQAAAABAAAAxwAAAAAACAAIAAgAEk+AAAAnEAAST4AAACcQUGhvdG9TY2FwZQAyMDE4OjExOjIzIDE1OjQ2OjE1AAAEkAAABwAAAAQwMjIxoAEAAwAAAAH//wAAoAIABAAAAAEAAAOEoAMABAAAAAEAAAOEAAAAAP/hDk1odHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+Cjx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IlhNUCBDb3JlIDQuMS4xLUV4aXYyIj4KIDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+CiAgPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIKICAgIHhtbG5zOnhhcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIgogICAgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIKICAgIHhtbG5zOmRjPSJodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyIKICAgIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIKICAgIHhtbG5zOnhhcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIKICAgeGFwTU06RG9jdW1lbnRJRD0iRTg3QkEwMTRDQzY1RENDQTg3NzA1MzQyMEQ4QkUwQTciCiAgIHhhcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6NzBDODFEM0RGQ0VFRTgxMTlCRjM4MkI1NDE1MjkwQTEiCiAgIHhhcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0iRTg3QkEwMTRDQzY1RENDQTg3NzA1MzQyMEQ4QkUwQTciCiAgIGRjOmZvcm1hdD0iaW1hZ2UvanBlZyIKICAgcGhvdG9zaG9wOkxlZ2FjeUlQVENEaWdlc3Q9IjJEQzc3MkY3MTkwRkI3REI1QjY4QTlENEVGRUY5MjA2IgogICBwaG90b3Nob3A6Q29sb3JNb2RlPSIzIgogICB4YXA6Q3JlYXRlRGF0ZT0iMjAxOC0xMS0yM1QxNTozNjoyOCswNzowMCIKICAgeGFwOk1vZGlmeURhdGU9IjIwMTgtMTEtMjNUMTU6NDY6MTUrMDc6MDAiCiAgIHhhcDpNZXRhZGF0YURhdGU9IjIwMTgtMTEtMjNUMTU6NDY6MTUrMDc6MDAiCiAgIHhhcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNiAoV2luZG93cykiPgogICA8eGFwTU06SGlzdG9yeT4KICAgIDxyZGY6U2VxPgogICAgIDxyZGY6bGkKICAgICAgc3RFdnQ6YWN0aW9uPSJzYXZlZCIKICAgICAgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDo0NDJFNEQyMkZDRUVFODExOTg5RkQ3MjYzNEEyMTMwOSIKICAgICAgc3RFdnQ6d2hlbj0iMjAxOC0xMS0yM1QxNTo0NTozMCswNzowMCIKICAgICAgc3RFdnQ6c29mdHdhcmVBZ2VudD0iQWRvYmUgUGhvdG9zaG9wIENTNiAoV2luZG93cykiCiAgICAgIHN0RXZ0OmNoYW5nZWQ9Ii8iLz4KICAgICA8cmRmOmxpCiAgICAgIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiCiAgICAgIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6NzBDODFEM0RGQ0VFRTgxMTlCRjM4MkI1NDE1MjkwQTEiCiAgICAgIHN0RXZ0OndoZW49IjIwMTgtMTEtMjNUMTU6NDY6MTUrMDc6MDAiCiAgICAgIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCBDUzYgKFdpbmRvd3MpIgogICAgICBzdEV2dDpjaGFuZ2VkPSIvIi8+CiAgICA8L3JkZjpTZXE+CiAgIDwveGFwTU06SGlzdG9yeT4KICA8L3JkZjpEZXNjcmlwdGlvbj4KIDwvcmRmOlJERj4KPC94OnhtcG1ldGE+CiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAKPD94cGFja2V0IGVuZD0idyI/Pv/tACxQaG90b3Nob3AgMy4wADhCSU0EBAAAAAAADxwBWgADGyVHHAIAAAIAAQD/2wBDAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/2wBDAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD+gr9kH9kbwB8afAb3/iKxT7ZZSywRzLkeY0TsqbsHCrJtAbrgHPJr7Dtv+CdHwWvLKK4S1bLZRw3DpNEzRTRyD+GWN0dJB2kBxxisP/gmbes3w61Gxu9sV9BfTF0z8s0RmfbPATjzI2HXAyjAqwBFfpSkQtdRvok4gvki1FUAwEuci1u9voJlS1lYf89TM55kY15M8XSxGDq4ijJ/w6tKrTelSjXppt06sd6dWlOLhKMkm+ZNe7yt7unKDcJK0k4zi1qpxbSvF7SjJNSjJaNLvt+OHxQ/ZX/Zm8C3njnQdQsdau9a8AfCTXPjLrFrZae7WVx4a0J50n0u01XzGiHiWd4oGi0uWFStpf2d6ZHjd0X8q77/AIJhfC3RfiD8QvHkv7Q3ifwV+0hr3hXwR4j+Kema1pGkXvwh0fQ9e3XXhLwl4b0jxXo1haah4T0J4ovCsl94Z8bL4hN5p5m1W80zUdXhtW/bX9pHwzrf/DR+geFZ7TWm8F/tOaJpnw+1/W9KSaCPTPD3g+K48UfETwrcapbyJcaXJ488MeF7Hw99sgaK8j0/Vb+TTZYbu3a8s/Mfj3+zH8JdW+IM/wActch1+fVNIsNXvNf8NTaha614I8TaX/Yeg217pl74W8R2Or2Njb3UHgrwld3MegyaMuo3vhjRpNQNxHFMk/4xmWZ1sPjasXiqtP20Z2UVGopxpzhyRcZprlqOMm0/twhJ+7FJ/v3AWEyrDUMKpuV80wMcQ5eww+M9pUhOlD6vONWLjChUxdLGUZ07cyq0cPVm3CCv/Kdpfw0+KFt8PfG3wyvPhv8AB74Jad8OfiL8XfhLrXxzl+I9ze6ZpQ8L3yvHr/gX4VXkVz4y8Qanc6j4j0+wtru+1Y6LZ6jc/bb24jt7Vwfp74D/ALLfwv8Aiz8FvDWoeHbvVda1fwra6H4J8RajqdvcwyX3jLRNA8Pz69NDJcFn1G0a61OPbqMZeG7nE/lvLs8xvo74f+BPDviW1+NfxS+I1/oE3iL4jT2/izwdqvib+z2i+HHj74v/AAhbxP4l0H4dy3KRz6dpVh4a8W+EbC9aN3v9Z1nTPEevTyIl1Alt9b/8E8fhD4kt/hRo2qeLfDlt4Z1jxrqXi341a14dt9xg8P2/iqSG90TSn3xxEXMOh2ukS3UW0mCeeSLJMYqq+PqVbUqU3CvPF4WlFQk0qlXFR95/vJ1Kk0r8jtKFOM7L2cXLnn+28S0cjyrIsyx8cDhqFbCU3iJShHljOpLCzr1XD2jnVqKL9x2cacJtJUocyc/iOX9n/wAC6ZLJpsmhWrSafI9k7M8pZntGMDMxDAFi0ZJIABPQCivffEcgPiHXjuPOtap0zj/j+n6Y4/Kiv2GOS5LGMYugpOKinJ1J3k0opy0la7aT0027n8RSzzN5yc3j8QnKTk0puybabS9LafLzv+s/7CFzcaf8Gtb1LT/D2peJ9VsryaTTtI0e7sbDVLmY3JQra3upT21lbYVmeT7RKIZFQqVckA/o7our3l3dWFvqkX2DUbjRLi8Gl3c9odTiEFxYi4VxayyQ3C2r3Mcc9xaloAzRk7PMQV+aH7DPjrSfAHwd1rXdSVrm4N7cWulaTDJGl3qupM8rQ2dtvOI0H+uu7lwY7O2VpXDMY43r6pr3xj8U69d+L9Lhln1i28Q2+sW/iOxsLSN/Dc9nb3Vja+HNG1m+lSKHRpLG8mTUtCMsias0xub63ned3f8AMeMOIKOWcRYWpQxGIxFWpCrHG5Vl1Gm6kqFBRjSq4yrG061SraUqNKrGUsPCnJOUISXN9xwdwXi+KcsxVSpVy7KsFhqko0c3zOrVpqtiKqpxWEo89T2EMPRlerWrwpKpKrUVFOtNKFL9Dvij4c0Txr4du/DuuQ3q20klvd2mp6Vf3Ok65oOsWUon0vXvD2t2Lx3uia7pdyq3Gm6layLLFMrRSLNazXFvN+TnjX9mDx5Y3/juz139rj46+LfBPjt2j1LwnqVh8OrDUbPQ57CTT9Q8O6N4v0nwtaXehWOuGe7vtc1Hw/pejeI7zULy5ltNa0+EWtva9z8YIdT/AGgde8F6j/wuDxt+zB8d/hloPi/RLTUfDumabNp/iXSvGsWhNe3MFt4iiltUgkm0KwuUtQJ72IG6jsbm4s5J3PgWjfD79s3RviB4SvPFv7UXgL4lfD+DXrN/iHp+q+CZLPX9e8LWGg6nZi08NLZRwaT4Z1rVNal0nUtWu7LyrSRreVrWK3hM1jffD1Mwp4tTxFLHUIOXPKdGth5xqxmpc0YRvQqKlUajFpqUJc7UJcvxL9X4L4ZzHh6lKOIx+Gw1V0pVa2Br4WrWUpxqSdGtluM+qYrBV6WKpU6NalisJiaTnKapVEnRueKfEz9jr4OeMPiPoXjLU/8AhNLfTtAt/Ddonw10fxdf6Z8LtYfwto9toOgXWueFYIzJfXFnoFnYaLcxw6naWetaZp1haa7a6nFblZP1J+C3hudvDHjnxA9s0UFj4buLa3bCqslxdRuixLAg2hYYlJA2JHFwqDsPi26+GnxCuviNr/iPUvjnc2/w9u7oPpXgDRfBvhrTJtL0ZdHWxubK98dXhvNYkmm1B7jWDq1pBp9za5tLOGaOG1kef9FvhfqXh2P9nu+m8L6lDqen3mkTrZ6oJ3vob+2sLVrCG6N4W36iZvIkeS/V3ju5SZ0aRJAxMtzDCwzPK/7RxcqtClK8VD2j9jNU+ejD95GnLmhWjDm5E4yVNJVOVKUfQ8TcbjVwnKnTqzxXtI4bBObjiPZ0I1+WdWlKVSnTSqOlRqRbgpxkk+WcuWx+BPiWfUR4i18C2gYDWtVAb7cy7sX0/O3yDtz125OOmaKr+ItQh/4SDXd/2hn/ALZ1PcyQHYzfbZ9zJ+++6Tkr7Yor9gVfDtJrHys0mr4mg39m1/3b12vq9t3pf+YPZS/6Bab8+Wr5a/xl2XRbbH2Z+x7JrWs6HeJqoeylXUzp1lbFvMisLe5uzHC1sQrJJFPI5ubq5GFvSqq7hY1ij/SLW7PV/hxdaT8SNS8O6TrOg6Xqeo+FvA3hXVLy5s/7NjiilFp4oiVEntZLzU1tb6e8mu42u7uS8ad2VzbPB8N/saXHhvWPh5c6fq2v6L4a1myvJjpmpareixhuJXmeVLCZ5miDWs74l82KSSa2dEkghmZ2jb6zm+KHwh13UtZTxJ4k8OX2o6fLBY+I9A1PxJqd1o2lar5YuZNT0DU/Btxqi6e+sKwvbjT76yWNzNLLaXAhcRx/j2JUqGcZ1OpWdLMZ4vDV8DmOOqRpYanWpWrRr4lVMLioYlYeUocuDUH7SpOjXjRl9Uh7P9wyHNKeOynKsPTw3tMJgsLicLm2V4GhUqYirhMRKlh+XBzp4rCzoRxinUjUxqrc+HTq4WtVh9ebr+ZeK/Bln4o+Eg1428kbxal4lvhDLP5sWnXdv4h0ozwaI7KtxaaHqFh4mto5tKQSQ22q6HFeQNE99dCT8oPHPwn/AGtL3x1DafAL493Ghw639qb/AIQLx3o2gazHp1xbQNdzt4c1/VLI3x08QqZW0rVZrq5s/l8i8lgZYIv18+I3xp8B6h4ch8L+HtR0ePRolhspRp0MljpsNslx9pt9G0aC9ln1SaO9viupaxrOpyC/1e7trMfZbG1t1jl/KJv2+fCHgn4oat4e+G8vgLVdevp5vCOkeLPECX2tJZC28ybxPd2yR3WmeG9K01ri1ka+1zW75mk0fR0kVBCzib5evDEwzBU8ndPHOhl+GpYutHDxq4OriadOMKtWEakKkZRbXNCrCKk1zKPJGLiv3/gPMM4/srNqv9nYarVljcfjMBl+bSoyo4XC4iqpYeONeI0oKjeVWtTox9u6cJzhz1Kkm+w+GP7Af7Tnj/XrW7/ad/aF8SeK/DttPBczeAfBd5BpujXqDDGLVk0iw0ixmtTvVXtvI1G4YFglxBgtX6l+PviL8IfgX8KLjQNf8d+DfB1jpHh82Gladd6vZ2t0lpbWnlW9ra6NbvNqTiOOMRLFHZvkgAfMQT8YQeBf2qvjVY3cniH41+HPAnhy+l0OPS7+21WT7Drmn3Usn9tXEXhbwdD4Yk046Olu0NhDrWpO2pXJimlQWLLNN8r69+yJ8OPEviHxnpepfEfVNb03wq9+l7qp1Oy0mPxBBHZsy6teWthcwmQJqdveafJpUF5emZV+2NdmC2vVbpw+VZhi61Otj6ypqMo8lPD0IU4Ri3F+5CMacE5O15OHO2vf2SXznEmZZTxTGpQ4j4vymOGyunKvPJ+FcDz4SjUlCMH/ALXONHDuvOcvY8rpV6qanCSUoS5Pz/8AEP7ZPwRbX9cZfEWoSKdY1IrJF4a1popFN7MQ8bPZo5Rx8yFkVipBZVOQCvhTxN+zVZw+JPEEOn2uky2EWt6tHYyDUIMSWaX9wts436TI+HhCN88jtz8zscsSv1iOXYblj/tFfaP2qXaH93+uX1PyX/V7gm+lbHWvpfEUE7e5uvq+j1d10+RoeP8Axh4tm0LypfFHiKWP+3bJ/Lk1vUnTfFf6h5b7GuSu+PYuxsZTau0jAo+A3iPxDp/xevLGw13WbKyvtE1tr2ztNTvra1vGtL+JrVrq3hnSK4a2aSQ25lRzCXcx7SzZKK48+/jY3/D/AO20j6Dgn/kiMw/6/wAv/TtM+xPF3iLxAnh/V2TXdZRl0fVpFZdTvVZXGn3BDqROCHBAIYcg85r5Z0i7u7LV/Cuo2VzcWmoWt7pM9rf2s0lveW0y39hCs0F1EyTwyrDJJEskbq4id4wQrMCUV4OU/FiP+4f5SPTwf+4Yr/r3V/8ATVU/ZOPxDr8UAji1vV4o+G8uPUr1E3EgltqzBdxPJOMk818UeCte1ye68VSTazqsz+T4pi3y6jeSP5Y8capbCPc8xOwW8UUATO3yYo4sbEVQUV9TU2of4I/mfhWQ/wADO/8AHhv/AEqseDa1qepR6xq0ceoX0ccep36IiXc6oiLdSqqIqyBVVVACqAAAAAMUUUUz9CWy9F+R/9k=");
            Icon = Icon.FromHandle(bmp.GetHicon());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Image Files(*.jpg; .jpeg; .gif; .bmp; .png)|*.jpg; .jpeg; .gif; *.bmp ;*.png"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(new Bitmap(open.FileName));
                if (bmp.Width <= bmp.Height && bmp.Height >= 281)
                {
                    bmpResize = new Bitmap(bmp, (int)(bmp.Width / ((float)bmp.Height / 281)), 281);
                }
                else if (bmp.Width > bmp.Height && bmp.Width >= 547)
                {
                    bmpResize = new Bitmap(bmp, 547, (int)(bmp.Height / ((float)bmp.Width / 547)));
                    MessageBox.Show(bmpResize.Width + " - " + bmpResize.Height);
                }
                else
                {
                    bmpResize = bmp;
                }
                pictureBox1.Image = bmpResize;
                textBox1.Text = open.FileName;
            }
        }

        private void Decrypt(object sender, EventArgs e)
        {
            int count = 0;
            if (bmp == null)
            {
                MessageBox.Show("Choose the image containing message");
                return;
            }
            StringBuilder rawMessage = new StringBuilder();
            bool endMarkFound = false;
            for (int i = 0; i < bmp.Height; i++)
            {
                count++;
                if (AddBitOfMessage(i, ref rawMessage))
                {
                    endMarkFound = true;
                    break;
                }
            }
            Clipboard.SetText(rawMessage.ToString());
            if (!endMarkFound)
            {
                MessageBox.Show("Can not find end point of the message in this picture.");
            }
        }
        private bool AddBitOfMessage(int i, ref StringBuilder rawMessage)
        {
            for (int j = 0; j < bmp.Width; j++)
            {
                rawMessage.Append(Convert.ToString(bmp.GetPixel(i, j).R, 2).PadLeft(8, '0')[7]);
                if (rawMessage.ToString().Contains(StringToBinary(END_MARK)))
                {
                    rawMessage.Remove(rawMessage.Length - 56, 56);
                    richTextBox1.Text = ToVietnamese(BinaryToString(rawMessage.ToString()));
                    return true;
                }
            }
            return false;
        }
        public static string StringToBinary(string message)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in message)
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string BinaryToString(string binary)
        {
            try
            {
                List<Byte> byteList = new List<Byte>();

                for (int i = 0; i < binary.Length; i += 8)
                {
                    byteList.Add(Convert.ToByte(binary.Substring(i, 8), 2));
                }
                return Encoding.ASCII.GetString(byteList.ToArray());
            }
            catch
            {
                MessageBox.Show("Invalid binary string.");
                return string.Empty;
            }
        }

        private string ToVietnamese(string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(message);

            //lower case
            builder.Replace("a{0}", "à");
            builder.Replace("a{1}", "á");
            builder.Replace("a{2}", "ả");
            builder.Replace("a{3}", "ã");
            builder.Replace("a{4}", "ạ");

            builder.Replace("a{5}", "ă");
            builder.Replace("a{6}", "ằ");
            builder.Replace("a{7}", "ắ");
            builder.Replace("a{8}", "ẳ");
            builder.Replace("a{9}", "ẵ");
            builder.Replace("a{10}", "ặ");

            builder.Replace("a{11}", "â");
            builder.Replace("a{12}", "ầ");
            builder.Replace("a{13}", "ấ");
            builder.Replace("a{14}", "ẩ");
            builder.Replace("a{15}", "ẫ");
            builder.Replace("a{16}", "ậ");

            builder.Replace("d{0}", "đ");

            builder.Replace("e{0}", "è");
            builder.Replace("e{1}", "é");
            builder.Replace("e{2}", "ẻ");
            builder.Replace("e{3}", "ẽ");
            builder.Replace("e{4}", "ẹ");

            builder.Replace("e{5}", "ê");
            builder.Replace("e{6}", "ề");
            builder.Replace("e{7}", "ế");
            builder.Replace("e{8}", "ể");
            builder.Replace("e{9}", "ễ");
            builder.Replace("e{10}", "ệ");

            builder.Replace("i{0}", "ì");
            builder.Replace("i{1}", "í");
            builder.Replace("i{2}", "ỉ");
            builder.Replace("i{3}", "ĩ");
            builder.Replace("i{4}", "ị");

            builder.Replace("o{0}", "ò");
            builder.Replace("o{1}", "ó");
            builder.Replace("o{2}", "ỏ");
            builder.Replace("o{3}", "õ");
            builder.Replace("o{4}", "ọ");

            builder.Replace("o{5}", "ô");
            builder.Replace("o{6}", "ồ");
            builder.Replace("o{7}", "ố");
            builder.Replace("o{8}", "ổ");
            builder.Replace("o{9}", "ỗ");
            builder.Replace("o{10}", "ộ");

            builder.Replace("o{11}", "ơ");
            builder.Replace("o{12}", "ờ");
            builder.Replace("o{13}", "ớ");
            builder.Replace("o{14}", "ở");
            builder.Replace("o{15}", "ỡ");
            builder.Replace("o{16}", "ợ");

            builder.Replace("u{0}", "ù");
            builder.Replace("u{1}", "ú");
            builder.Replace("u{2}", "ủ");
            builder.Replace("u{3}", "ũ");
            builder.Replace("u{4}", "ụ");

            builder.Replace("u{5}", "ư");
            builder.Replace("u{6}", "ừ");
            builder.Replace("u{7}", "ứ");
            builder.Replace("u{8}", "ử");
            builder.Replace("u{9}", "ữ");
            builder.Replace("u{10}", "ự");

            builder.Replace("y{0}", "ỳ");
            builder.Replace("y{1}", "ý");
            builder.Replace("y{2}", "ỷ");
            builder.Replace("y{3}", "ỹ");
            builder.Replace("y{4}", "ỵ");

            // upper case
            builder.Replace("A{0}", "À");
            builder.Replace("A{1}", "Á");
            builder.Replace("A{2}", "Ả");
            builder.Replace("A{3}", "Ã");
            builder.Replace("A{4}", "Ạ");

            builder.Replace("A{5}", "Ă");
            builder.Replace("A{6}", "Ằ");
            builder.Replace("A{7}", "Ắ");
            builder.Replace("A{8}", "Ẳ");
            builder.Replace("A{9}", "Ẵ");
            builder.Replace("A{10}", "Ặ");

            builder.Replace("A{11}", "Â");
            builder.Replace("A{12}", "Ầ");
            builder.Replace("A{13}", "Ấ");
            builder.Replace("A{14}", "Ẩ");
            builder.Replace("A{15}", "Ẫ");
            builder.Replace("A{16}", "Ậ");

            builder.Replace("D{0}", "Đ");

            builder.Replace("E{0}", "È");
            builder.Replace("E{1}", "É");
            builder.Replace("E{2}", "Ẻ");
            builder.Replace("E{3}", "Ẽ");
            builder.Replace("E{4}", "Ẹ");

            builder.Replace("E{5}", "Ê");
            builder.Replace("E{6}", "Ề");
            builder.Replace("E{7}", "Ế");
            builder.Replace("E{8}", "Ể");
            builder.Replace("E{9}", "Ễ");
            builder.Replace("E{10}", "Ệ");

            builder.Replace("I{0}", "Ì");
            builder.Replace("I{1}", "Í");
            builder.Replace("I{2}", "Ỉ");
            builder.Replace("I{3}", "Ĩ");
            builder.Replace("I{4}", "Ị");

            builder.Replace("O{0}", "Ò");
            builder.Replace("O{1}", "Ó");
            builder.Replace("O{2}", "Ỏ");
            builder.Replace("O{3}", "Õ");
            builder.Replace("O{4}", "Ọ");

            builder.Replace("O{5}", "Ô");
            builder.Replace("O{6}", "Ồ");
            builder.Replace("O{7}", "Ố");
            builder.Replace("O{8}", "Ổ");
            builder.Replace("O{9}", "Ỗ");
            builder.Replace("O{10}", "Ộ");

            builder.Replace("O{11}", "Ơ");
            builder.Replace("O{12}", "Ờ");
            builder.Replace("O{13}", "Ớ");
            builder.Replace("O{14}", "Ở");
            builder.Replace("O{15}", "Ỡ");
            builder.Replace("O{16}", "Ợ");

            builder.Replace("U{0}", "Ù");
            builder.Replace("U{1}", "Ú");
            builder.Replace("U{2}", "Ủ");
            builder.Replace("U{3}", "Ũ");
            builder.Replace("U{4}", "Ụ");

            builder.Replace("U{5}", "Ư");
            builder.Replace("U{6}", "Ừ");
            builder.Replace("U{7}", "Ứ");
            builder.Replace("U{8}", "Ử");
            builder.Replace("U{9}", "Ữ");
            builder.Replace("U{10}", "Ự");

            builder.Replace("Y{0}", "Ỳ");
            builder.Replace("Y{1}", "Ý");
            builder.Replace("Y{2}", "Ỷ");
            builder.Replace("Y{3}", "Ỹ");
            builder.Replace("Y{4}", "Ỵ");

            return builder.ToString();
        }

        private static Bitmap Base64StringToBitmap(string base64String)
        {
            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer)
            {
                Position = 0
            };
            Bitmap bmpReturn = (Bitmap)Image.FromStream(memoryStream);
            memoryStream.Close();
            return bmpReturn;
        }
    }
}
