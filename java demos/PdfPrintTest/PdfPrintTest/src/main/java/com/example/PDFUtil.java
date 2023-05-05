package com.example;


import com.itextpdf.text.Document;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfWriter;

import java.io.File;
import java.io.FileOutputStream;

/**
 * @Author liyina
 * @create 2023/5/4 9:51
 */
public class PDFUtil {
    public static void createPdf() {

        String newPDFPath = "D:\\pdfTestNew.pdf";
        BaseFont bf;
        Font font = null;
        Document document = new Document();
        try {
            String font_cn = getChineseFont();
            bf = BaseFont.createFont(font_cn + ",1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            font = new Font(bf, 12);
            //生成
            PdfWriter.getInstance(document, new FileOutputStream(newPDFPath));
            document.open();
            document.add(new Paragraph("hello world"));
            document.add(new Paragraph("你好，世界!", font));
            document.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * 获取中文字体设置
     *
     * @return
     */
    private static String getChineseFont() {
        //宋体
        String font1 = "C:\\Windows\\Fonts\\simsun.ttc";
        java.util.Properties prop = System.getProperties();
        String osName = prop.getProperty("os.name").toLowerCase();
        System.out.println(osName);
        if (osName.indexOf("linux") > -1) {
            font1 = "user\\share\\fonts\\simsun.ttc";
        }
        if (!new File(font1).exists()) {
            throw new RuntimeException("字体文件不存在，影响导出pdf中文显示！" + font1);
        }
        return font1;
    }
}
