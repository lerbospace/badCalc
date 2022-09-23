string SebChem = @"Raya BAUTISTA

Ngawang CHODEN

Ciaran ERNST-RUSSELL

Ainsley FISHER

Brianna MCARDLE

Patricia NARAYAN

Mika PELJO

Jack PENNEY

Charlotte PRATT

Zoe RAINS

Samantha READ

Kuenden TAMANG

Lauren THERIN

Holly WEBB

Hannah WHITE

This is Spec Ops

Koan ANDERSSEN

Joshua CRAWFORD

Benjamin (Ben) GRAY

Theartha HARI NAIR

Sara HARRYSSON

Matilda JENKINS

Oliver JOHNSON

Esther KO

Stuart MANUEL

Noah NATH-HAMPTON

Kyuji OTA

Katie POLETTE

Alannah POPE

Charlie RHODES

Markus ZARAK
";


string sebSpec = @"Koan ANDERSSEN

Joshua CRAWFORD

Benjamin (Ben) GRAY

Theartha HARI NAIR

Sara HARRYSSON

Matilda JENKINS

Oliver JOHNSON

Esther KO

Stuart MANUEL

Noah NATH-HAMPTON

Kyuji OTA

Katie POLETTE

Alannah POPE

Charlie RHODES

Markus ZARAK 
";

string azharEnglish = @"Ali ALDLALLI

Toby BRENTON

Ellyse CALDER

Joshua CRAWFORD

Madison CUSICK

Hannah DEMPSEY

Jamie GRAY

Sara HARRYSSON

Phoebe HODGES

Mishaal KAMAL

Kayla MCDOUGALL

Claudia MIKK

Jasmine MILLER

Isaac MILLS

Declan MURPHY

Emily MUSCAT

Patricia NARAYAN

Katie POLETTE

Oliver PRICE

Zoe RAINS

Felicity ROSENOW

Rohan TAMPI

Mia TESOLIN

Holly WEBB";

string dek = @"

Abhijith KAVALIL BIJU

Adrianna HANSEN

Aimee CAMPBELL

Alannah POPE

Alessandra CASTILLON

Alexis AU

Alfie GRAY

Alivia PALASRINNE

Amelia CRISP

Amelia HEFREN-WEBB

Amit ARIAV

Anamika MCDONALD

Andrija MILOVANOVIC

Aneice MITCHELL

Angelina SUBRAMANIAM

Anna COLLINSON

Anna RAMSAY

Annalise BILBROUGH

Annie WALKER

Anurudh MAYILVAHANAN

April APPLEBEE

Aren CUPIT

Ash FORD

Ashley PETERSON

Ashlyn VINCENT

Austin PEARCE

Avalon FREZZA

Azhar HUSSAIN

Azira BOOTH

Ben FARLOW

Ben GORDON

Benila BLESSEN

Benjamin DOWSE

Bimo BIMO

Brandon LE

Bridget CLOUGH

Bridie WILLIAMS

Brooke MCFARLANE

Brooklyn-Lee MCCLUNG

Caitlin ORR

CARLO CORTES PEREZ

Charles MARPAUNG

Charlie KENNEDY

Charlie RHODES

Charlotte PRATT

Chelsea WILLS

Christina STEWART

Claire JONES

Clemente HEIN-ALATI

Cynthia GRAHAM

Cynthia SUN

Damian TINDALL

Dan FOX

Dante VEAL

Declan MURPHY

Eilis ROGIS

Elijah YEOH

Ellyse CALDER

Emily HICKEY

Emily MUSCAT

Ethan COPELAND

Ethan LEE

Ethan MCBAIN

Eve NOTT

Evelyn TURNER

Everson PALMER

Flynn LAMOND

Fraser MURRAY

Freya SANDEMAN

Gabrielle BROWN

George ILLINGWORTH

George XIN

Georgia BATH

Grace DUYZER

Grace KAVANAGH

Hannah WALLIS

Hansali ABEYA

Harrison D'ELBOUX

Helena BINUTTI

Holly PHILLIPS

Immy CHAMBERS

Imogen ROLPH

Ione BARLOW

Isaac MILLS

Ismeta MESKIN

Izzy MCEVOY

Jack HOGAN

Jacob MOORBY

Jada-Lily LAUVAO

Jade KINGSTON

Jade STEWART

Jaimie KAYE

Jake MARTIN

Jakobi MONAGHAN

James HENNECKE

Jamie GRAY

Jasmine NERDAL

Jason WINSTANLEY

Jasper CHAMBERLAIN

Jaxon BURGE

Jay-Ar Valentin DE LEON

Jaz CLARK

Jeremy BROTHERS

Joakim Sverre SCHUMACHER

Joel PIAZZA

John ESPIRITU

John PAYNTER

Joji HAMLYN-HARRIS

Jonathon HARPLEY

Josh TOOLE

Joshua VINER

Julian KNAPIK

Juliet DAVIDSON

Justin AMBATTU

Justin MARTINEZ

Kai BUCKLEY

Kate BATTEN

Katherine BARRATT

Katherine DONALD

Katie PIKE

Kayla MCDOUGALL

Kevin ROCHANABUDDHI

Kita SINCLAIR-SMITH

Kong ROCHANABUDDHI

Kurt LINDER

Kyuji OTA

Lachlan PRIDDLE

Lamese YOUNES

Lara WILLIS

Lauren DANIEL

Lauren THERIN

Leah TWYMAN

Lebron FIDER

Lehansa SAMARANAYAKE

Liam BATTERBURY

Lily HASKINS

Lisa MARSHALL

Livia HEIN-ALATI

Logan GOODCHILD

Lucas ADAMS

Lucas WONG

Lucy EMERSON-ELLIOTT

Luke BAKER

Luke TEMPLE-CLARKE

Luke WOOD

Maddy ENCHONG

Marcus UNGER

Mariah DRABSCH

Markus ZARAK

Martin BIJU

Matilda JENKINS

Max KNEZEVIC

May Thu Thu Khin KHIN

Mehal JHUNJHUNWALA

Meikah BRAMBOECK

Mercedes ELLIS

Mia COULTER

Miles JARMAN

Milly WHITEHEAD

Misa TAKARAGI

Mohammed ALDAGREER

Molly HANRAHAN

Mrat THEIN U

Natalie ROBINSON

Nathan LACHICA

Nathanielle SANTOS

Nayeon KIM

Neena MATTHEE

Neha SHIJO

Nick FLORES

Noa PADILLA

Noura AIIAF

Ohad GERSTENFELD

Oliver MEIR

Oliver PRICE

Otto HAWKINS

Owen BROOKS

Pasha AMAN

Pearl GUMA

Pranav KIRAN

Quan NGUYEN

Quan NGUYEN

Racquel MARTIN

Rebecca KORES

Rebecca MCKINNON

Reuben STERRITT

Riley HIGGS

Riley PATON

Robert HILSON

Robin ADAM

Rocio MELGAREJO TRIAY

Rohan TAMPI

Rudrakshi RAI

Ryan SMITH

Sam FORAN

Samir ALI

Samuel CAREY

Samuel VAN DUNK

Sara HARRYSSON

Saskia BLACKBURN

Scarlett RIXON

Sebastian SINGH

Sebastian TURNER

Sebastian YOUNG

Seini MELEKIOLA

Shauna WILLIAMS

Shona ROBINSON-WHYMAN

Sintayehu POLLOCK

Siobhan MCCARTHY

Sofia AGUANTA

Sofie LEFFERS

Stacie DYE

Stella COOPER

Syara PAHLEVI

Takuma ARAKAWA

Taneysha PHAVONG

Taylah REID

Teresa SONG

Theartha HARI NAIR

Thomas BOXALL

Tia BHASKAR

Tilly HISLOP

Toby DAVIS-LYON

Tully BAZ

Victor KYALO

Wesley ANDRESEN

Will MANNING

William LUDLOW

William MCKENDRY

William ROGERS

Yazid RAZAKI

Yuki OTA

Zachary DOWNEY

Zachary WARD

Zackory OLSEN

Zoe RALSTON";
List<String> sebChemSplit = SebChem.Split('\n','\r').ToList();

sebChemSplit.RemoveAll(index => string.IsNullOrWhiteSpace(index));

List<String> sebSpecSplit = sebSpec.Split('\n','\r').ToList();
sebSpecSplit.RemoveAll(index => string.IsNullOrWhiteSpace(index));

List<String> AzharEnglishSplit = azharEnglish.Split('\n', '\r').ToList();
AzharEnglishSplit.RemoveAll(index => string.IsNullOrWhiteSpace(index));

List<String> dekSplit = dek.Split('\n', '\r').ToList();
dekSplit.RemoveAll(index => string.IsNullOrWhiteSpace(index));


foreach (string str in sebChemSplit)
{
    Console.WriteLine(str);
}

Console.WriteLine("Spec");
foreach (string str in AzharEnglishSplit)
{
    foreach(string newstr in sebChemSplit)
    {
        if (newstr == str)
        {
            Console.Write("MatchFound:");
            Console.WriteLine(str);
        }
    }
}
Console.WriteLine("Chem");

foreach (string str in AzharEnglishSplit)
{
    foreach (string newstr in sebSpecSplit)
    {
        if (newstr == str)
        {
            Console.Write("MatchFound:");
            Console.WriteLine(str);
        }
    }
}
Console.WriteLine("dek");
foreach (string str in AzharEnglishSplit)
{
    foreach (string newstr in dekSplit)
    {
        if (newstr == str)
        {
            Console.Write("MatchFound:");
            Console.WriteLine(str);
        }
    }
}


