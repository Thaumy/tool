/*打开课程panel*/

function Open_panel() {
    var course_blockrrr = document.getElementsByClassName('panel panel-info');
    for (j = 1; j <= course_blockrrr.length - 1; j++) {
        course_blockrrr[j].children[0].children[7].click();
    };
};

function courseOK(course_block, k) {
    if ((course_block[k].getElementsByClassName('jsxm')[0].textContent === '尔雅' ||
            course_block[k].getElementsByClassName('jsxm')[0].textContent === '卓越') &&
        course_block[k].getElementsByClassName('kcgs')[0].textContent != '理学工学与医学类' &&
        course_block[k].getElementsByClassName('kcgs')[0].textContent != '艺术类') {
        return true;
    } else {
        return false;
    }
}

function sleep(d) {
    for (var t = Date.now(); Date.now() - t <= d;);
}

let times = 0;

/*点击选课按钮*/
function Click_button() {
    let course_block = document.getElementsByClassName('body_tr');

    let k = 0;
    setInterval(function () {
        Open_panel()
        if (k < course_block.length) {
            let btn = $('.body_tr').children(".an").children("button")[k];

            if (courseOK(course_block, k) && btn.innerText == '选课') {
                btn.click();
                sleep(800);
                try {
                    document.getElementById('btn_confirm').click();
                } catch (e) {
                    console.log("err")
                }
                sleep(800);
                try {
                    document.getElementById('btn_ok').click()
                } catch (e) {
                    console.log("err")
                }
            }
            k++
        } else {
            k = 0
        }
        times++;
        console.log(`-------------------${times}--------------------`);
    }, 2000)
};

function big_calcus_to_get_time() {}

/*刷新课程列表*/
function RefreshClasses() {
    let btn = document.getElementsByClassName('btn btn-primary btn-sm');
    btn[0].click();
    while (document.getElementById('more').style.display != 'none') {
        loadCoursesByPaged();
    }
};

/*入口在这*/
function StartSelecting() {
    document.getElementById("kxqxktskg").value = 0;
    //RefreshClasses();
    Click_button();
};

StartSelecting()