# langcs
Multi language manager for asp.net web forms and mvc

# How to use?

## Web.config - Add your language files folder

```
<appSettings>
    <add key="langCSPath" value="language/"/>
</appSettings>
```

## ~/language/en.xml - Create your first language xml file. (English)

File name is very important. Because filename will be your language code. There is an `id` attribute in `lang` tag. This is the key for identify your word. You can use any string but without any space. There is also an example with Guid.

```
<?xml version="1.0" encoding="utf-8" ?>
<langCS>
  <lang id="HelloWorld">Hello World!</lang>
  <lang id="good.luck">Good Luck!</lang>
  <lang id="848E0991-31F6-4D5C-B669-E9FCCD88CCBE">Some Text</lang>
</langCS>
```

## ~/language/tr.xml - Create your secondary language xml file. (Turkish)

`id` attribute is same with first language file. But text will be your translated word.

```
<?xml version="1.0" encoding="utf-8" ?>
<langCS>
  <lang id="HelloWorld">Merhaba Dünya!</lang>
  <lang id="good.luck">İyi Şanslar!</lang>
  <lang id="848E0991-31F6-4D5C-B669-E9FCCD88CCBE">Yazı</lang>
</langCS>
```

## Using in View Page (xxx.cshtml) for first language (English - /language/en.xml)

```
@using LangCSManager

....

<p>@LangCS.Translate("HelloWorld", "en")</p>
<p>@LangCS.Translate("good.luck", "en")</p>
<p>@LangCS.Translate("848E0991-31F6-4D5C-B669-E9FCCD88CCBE", "en")</p>
```

Also you can use in controller page, web form application or class library project. 
