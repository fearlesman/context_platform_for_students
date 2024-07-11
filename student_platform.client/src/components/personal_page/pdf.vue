<template>
    <div id="pdf-viewer">
      <canvas ref="pdfCanvas"></canvas>
    </div>
  </template>
  
  <script>
  import * as pdfjsLib from 'pdfjs-dist/build/pdf';
  
  export default {
    name: 'PDFViewer',
    props: {
      pdfUrl: {
        type: String,
        required: true
      }
    },
    data() {
      return {
        pdf: null,
        currentPage: 1
      }
    },
    mounted() {
      this.loadPDF();
    },
    methods: {
      loadPDF() {
        pdfjsLib.getDocument(this.pdfUrl).promise.then(pdf => {
          this.pdf = pdf;
          this.renderPage(this.currentPage);
        }).catch(error => {
          console.error('Error loading PDF:', error);
        });
      },
      renderPage(pageNumber) {
        this.pdf.getPage(pageNumber).then(page => {
          const scale = 1.5;
          const viewport = page.getViewport({ scale });
  
          const canvas = this.$refs.pdfCanvas;
          const context = canvas.getContext('2d');
          canvas.height = viewport.height;
          canvas.width = viewport.width;
  
          const renderContext = {
            canvasContext: context,
            viewport
          };
  
          page.render(renderContext);
        });
      }
    }
  }
  </script>
  
  <style scoped>
  #pdf-viewer {
    width: 100%;
    height: 600px;
    border: 1px solid #ccc;
  }
  </style>