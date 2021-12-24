# 万年历&记事本

## 概述

+ 以C#为基础，主要有以下两个功能：万年历和记事本

+ 万年历：可以查看当天和当天所在月的信息以及天气信息，并且可以点击按钮查看邻近的年月。有效查询时间是1901年02月19日 00：00：00至2101年01月28日 23：59：59。

+ 记事本：具有基本的记事功能，其中主要有四大功能模块，文件操作，文件编辑，格式，查看，帮助。

## 创意点

+ 十二节气获取：这里根据网上的进行了改进，对于某一天不针对二十四个节气进行循环判断，而是对于某一天只针对四个节气进行判断，因为根据一个新历的一个月中只会有两个节气，所以当知道某天的所在月份时，它可能有的节气只可能是它该月的两个以及上一个月的第二个以及下一个月的第一个，只取这四个进行判断。
+ 干支月的判定是依据节气来的。下图中的月份既不是新历的月份也不是农历的月份，而是根据二十四节气每两个节气所在的月份
+ 对于记事本注意当前文本的保存，于是设置了IsSave以及文件的标题来区分其是否保存或者是否已存在，然后根据不同情况执行不同操作。
## 发展空间

+ 该项目的主要思想是使人们方便记录生活的小事或小想法，过好每一天，而该项目由于时间问题没能完整实现，其中缺少了提醒事项的功能，这部分涉及数据库的功能，如果能实现，不仅对能力提升还是系统功能完善都是很好的。
